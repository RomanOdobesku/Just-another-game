﻿using UnityEngine;
using System.Collections;
using System;

public class HealthHelper : MonoBehaviour
{

    public float MaxHealth = 100;
    public float DamagePerSecond = 0.1f;
    public float DamageRobotSensivity = 0.1f;
    public float DamagePerSecondInLava = 0.1f;
    public int Group = 0;
    public float HeightOffset = 3;
    public Camera Camera;
    public GameObject Explosion;
    public bool DynamicHealthBarCreate = true;
    public bool Player = true;

    [SerializeField] private float _health = 0;

    private Rigidbody _rigidbody;
    private UIHealthBarHelper _UIHealthBarHelper;

    private bool _lava = false;

    public bool Lava
    {
        set => _lava = value;
        get => _lava;
    }

    //private CollisionObserver _collisionObserver;

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>() as Rigidbody;
        _health = MaxHealth;
        if (!Camera)
            Camera = Camera.main;

        if (DynamicHealthBarCreate)
        {
            GameObject healthBar = Instantiate(Resources.Load("HealthBarSlider"), Vector3.zero, Quaternion.identity) as GameObject;
            _UIHealthBarHelper = healthBar.GetComponent<UIHealthBarHelper>() as UIHealthBarHelper;
            healthBar.transform.SetParent(GameObject.Find("Canvas").transform);
            _UIHealthBarHelper.NPC = _rigidbody.transform;
            _UIHealthBarHelper.HeightOffset = HeightOffset;
            _UIHealthBarHelper.MaxHealth = MaxHealth;
            _UIHealthBarHelper.Health = _health;
            _UIHealthBarHelper.RobotCollider = GetComponentInChildren<SphereCollider>() as Collider;
            _UIHealthBarHelper._Camera = Camera;
        }
        //_collisionObserver = GetComponent<CollisionObserver>() as CollisionObserver;
    }

    private void FixedUpdate()
    {
        GetDamage(DamagePerSecond * Time.deltaTime, null);
        if (Lava)
            GetDamage(DamagePerSecondInLava * Time.deltaTime, null);
    }

    public void GetRobotHit(Collision collision)
    {
        float me = _rigidbody.velocity.magnitude;
        me *= me;
        float enemy = collision.rigidbody.velocity.magnitude;
        enemy *= enemy;
        float relVel = collision.relativeVelocity.magnitude;
        GetDamage(enemy / (me + enemy) * relVel * DamageRobotSensivity, null);
        print(gameObject.name + " take damage: " + enemy / (me + enemy) * relVel * DamageRobotSensivity);
    }

    public void GetDamage(float damage, HealthHelper killer)
    {
        _health -= damage;
        _UIHealthBarHelper.Health = _health;
        if (_health <= 0)
        {
            GameObject explosion = Instantiate(Explosion, _rigidbody.transform.position, Quaternion.identity);
            ParticleSystem explosionParticleSystem = explosion.GetComponent<ParticleSystem>() as ParticleSystem;
            _UIHealthBarHelper.DisableSlider();
            if (Player)
                Camera.transform.SetParent(null);
            Destroy(gameObject);
            Destroy(explosion, explosionParticleSystem.main.duration);
        }
    }
}

