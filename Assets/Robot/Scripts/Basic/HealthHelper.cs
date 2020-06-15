using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class HealthHelper : MonoBehaviour
{

    public float MaxHealth = 100f;
    public float ValueRepairKit = 50f;
    public float ValueDamagRedField = 50f;
    public float DamagePerSecond = 0.1f;
    public float DamageRobotSensivity = 0.1f;
    public float DamagePerSecondInLava = 0.1f;
    public int Group = 0;
    public float HeightOffset = 3f;
    public Camera Camera;
    public GameObject Explosion;
    public bool DynamicHealthBarCreate = true;
    public bool Player = true;
    public bool Enemy;

    public float _health = 0;

    private Rigidbody _rigidbody;
    private UIHealthBarHelper _UIHealthBarHelper;
    private bool _death;

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
        if (SceneManager.GetActiveScene().name != "Fight")
        {
            if (Player)
            {
                float multiplier;
                multiplier = PlayerPrefs.GetInt("Health");
                MaxHealth = MaxHealth * (1 + multiplier / 5);
            }
            if (Enemy)
            {
                float multiplier;
                multiplier = PlayerPrefs.GetInt("Damage");
                DamageRobotSensivity = DamageRobotSensivity * (1 + multiplier / 5);
            }
        }
        _health = MaxHealth;
        if (!Camera)
            Camera = Camera.main;

        if (DynamicHealthBarCreate)
        {
            string name;
            if (Enemy)
                name = "HealthBarSliderEnemy";
            else
                name = "HealthBarSliderAlly";
            GameObject healthBar = Instantiate(Resources.Load(name), Vector3.zero, Quaternion.identity) as GameObject;
            _UIHealthBarHelper = healthBar.GetComponent<UIHealthBarHelper>() as UIHealthBarHelper;
            healthBar.transform.SetParent(GameObject.Find("Canvas").transform);
            healthBar.transform.SetAsFirstSibling();
            _UIHealthBarHelper.VisibleChecker = GetComponentInChildren<VisibleChecker>();
            _UIHealthBarHelper.HeightOffset = HeightOffset;
            _UIHealthBarHelper.MaxHealth = MaxHealth;
            _UIHealthBarHelper.Health = _health;
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
    }

    public void GetRepairKit() //правильнее GerMedicineCabinet
    {
        _health += ValueRepairKit;
        _health = Math.Min(MaxHealth, _health);
        _UIHealthBarHelper.Health = _health;

    }

    public void EnterField()
    {
        _health -= ValueDamagRedField;
        _health = Math.Max(0, _health);
        _UIHealthBarHelper.Health = _health;
    }

    public void GetDamage(float damage, HealthHelper killer)
    {
        //print(gameObject.name + " take damage: " + damage);
        _health -= damage;
        _UIHealthBarHelper.Health = _health;
        if (_health <= 0 && !_death)
        {
            _death = true;
            GameObject explosion = Instantiate(Explosion, _rigidbody.transform.position, Quaternion.identity);
            ParticleSystem explosionParticleSystem = explosion.GetComponent<ParticleSystem>() as ParticleSystem;
            _UIHealthBarHelper.DisableSlider();
            if (Player)
                Camera.transform.SetParent(null);
            if (CompareTag("NPC Usual"))
            {
                GameObject.Find("NPC").GetComponent<NPCHelper>().DeadUsualNPC();
                Debug.LogWarning("death npc");
            }
            if (CompareTag("NPC Elite"))
            {
                GameObject.Find("NPC").GetComponent<NPCHelper>().DeadEliteNPC(transform.GetChild(0));
            }
            if (CompareTag("NPC Allies"))
            {
                GameObject.Find("NPC").GetComponent<NPCHelper>().DeadAlies();
                if (SceneManager.GetActiveScene().name != "Fight")
                    GameObject.Find("Death Panel").GetComponent<Death>().ActiveDeathPanel();
            }
            if (CompareTag("Robot Player"))
            {
                GameObject.Find("Death Panel").GetComponent<Death>().ActiveDeathPanel();
            }
            Destroy(gameObject);
            Destroy(explosion, explosionParticleSystem.main.duration);
        }
    }

    public float getHealth()
    {
        return _health;
    }
}