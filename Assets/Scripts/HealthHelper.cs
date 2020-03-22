using UnityEngine;
using System.Collections;
using System;

public class HealthHelper : MonoBehaviour
{

    [SerializeField] private float _MaxHealth = 100;
    [SerializeField] private float _Health = 100;
    [SerializeField] private int _Group = 0;
    [SerializeField] private float _Height = 0;
    [SerializeField] private float _DamagePerSecond = 0.1f;
    [SerializeField] private bool _DynamicHealthBarCreate = true;
    private bool _dead;

    public RobotPlayer.HealthSettings Init
    {
        set
        {
            _MaxHealth = value.MaxHealth;
            _Health = value.Health;
            _Group = value.Group;
            _DamagePerSecond = value.DamagePerSecond;
            _DynamicHealthBarCreate = value.DynamicHealthBarCreate;
            _Height = value.Height;
            if (_uIHealthBarHelper != null)
            {
                _uIHealthBarHelper.Height = _Height;
            }

        }
    }

    public float MaxHealth
    {
        get => _MaxHealth;
    }

    public float Health
    {
        get => _Health;
    }

    public bool Dead
    {
        get { return _dead; }
        set { _dead = value; }
    }

    public bool hit = false;


    public int Kills { get; private set; }

    UIHealthBarHelper _uIHealthBarHelper;
    // Use this for initialization
    void Start()
    {
        if (_DynamicHealthBarCreate)
        {
            Transform healtBarSlider = transform.GetChild(2);
            healtBarSlider.SetParent(GameObject.Find("Canvas").transform);
            _uIHealthBarHelper = healtBarSlider.GetComponent<UIHealthBarHelper>();
            _uIHealthBarHelper.NPC = transform;
            _uIHealthBarHelper.Height = _Height;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            GetDamage(10, null);
            hit = false;
        }
    }

    private void FixedUpdate()
    {
        GetDamage(_DamagePerSecond * Time.deltaTime, null);
    }

    public void GetDamage(float damage, HealthHelper killer)
    {
        if (Dead)
            return;

        _Health -= damage;
        if (_Health <= 0)
        {
            Dead = true;
            _uIHealthBarHelper.DisableSlider();
        }

        /*
        if (Health <= 0)
        {
            Dead = true;
            killer.Kills += 1;
            GetComponentInChildren<PlayerShooting>().Drop();
            GetComponent<Animator>().SetBool("Dead", true);
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            _uIHealthBarHelper.DisableSlider();
        }
        */

    }
}

