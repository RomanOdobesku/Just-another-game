using UnityEngine;
using System.Collections;
using System;

public class HealthHelper : MonoBehaviour
{

    public int MaxHealth = 100;
    public float Health = 100;
    public int Group = 0;
    public float Height = 3;
    public float speedDying = 10;

    public bool isDynamicHealthBarCreate = true;
    private bool _dead;
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
        if (isDynamicHealthBarCreate)
        {
            GameObject healtBarSlider = Instantiate(Resources.Load("HealthBarSlider"), Vector3.zero, Quaternion.identity) as GameObject;
            healtBarSlider.transform.SetParent(GameObject.Find("Canvas").transform);
            _uIHealthBarHelper = healtBarSlider.GetComponent<UIHealthBarHelper>();
            _uIHealthBarHelper.NPC = transform;
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
        GetDamage(speedDying * Time.deltaTime, null);
    }

    public void GetDamage(float damage, HealthHelper killer)
    {
        if (Dead)
            return;

        Health -= damage;
        if (Health <= 0)
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

