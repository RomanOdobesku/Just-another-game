﻿using UnityEngine;
using System.Collections;
using System;
using Boo.Lang.Runtime.DynamicDispatching;

public class HealthHelper : MonoBehaviour
{

    public float MaxHealth = 100f;
    public float ValueRepairKit = 50f;
    public float DamagePerSecond = 0.1f;
    public float DamageRobotSensivity = 0.1f;
    public float DamagePerSecondInLava = 0.1f;
    public int Group = 0;
    public float HeightOffset = 3f;
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
        float enemy = collision.rigidbody.velocity.magnitude;
        float relVel = collision.relativeVelocity.magnitude;
        if (me < enemy)
        {
            _rigidbody.AddForce(collision.GetContact(0).normal * relVel * 0.1f, ForceMode.Impulse);
        }
        me *= me;
        enemy *= enemy;
        GetDamage(enemy / (me + enemy) * relVel * DamageRobotSensivity, null);
        print(gameObject.name + " take damage: " + enemy / (me + enemy) * relVel * DamageRobotSensivity);
    }

    public void GetRepairKit()
    {
        _health += ValueRepairKit;
        _health = Math.Min(MaxHealth, _health);
        _UIHealthBarHelper.Health = _health;
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
