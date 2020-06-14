using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy : MonoBehaviour
{
    //public Transform FollowObject;
    public bool need_charge = false;
    private HealthHelper healthHelper;
    private Transform[] followObjects;
    bool Attack = true;
    //public float StopRadius = 25;
    public float ActivateRadius = Mathf.Infinity;

    public float jump_cooldown = 100;

    private NPCHelper npchelper;

    float nitro_amount = 100;
    private Rigidbody _rigidbody;
    int prev_allies_count = 5;
    private RobotMotion _robotMotion;
    private Transform _robot;
    private bool speedUp = true;
    private Vector3 _targetPosition;
    GameObject[] medicine_cabinets;

    void Start()
    {
        npchelper = GameObject.Find("NPC").GetComponent<NPCHelper>() as NPCHelper;

        GameObject[] temporary = GameObject.FindGameObjectsWithTag("NPC Allies");

        followObjects = new Transform[1 + temporary.Length];
        for (int i = 0; i < temporary.Length; ++i)
        {
            followObjects[i] = temporary[i].transform.Find("Robot").transform;
        }

        followObjects[temporary.Length] = GameObject.Find("Robot Player").transform.GetChild(0);

        _rigidbody = GetComponentInChildren<Rigidbody>() as Rigidbody;
        medicine_cabinets = GameObject.FindGameObjectsWithTag("Medicine cabinet");
        healthHelper = GetComponent<HealthHelper>() as HealthHelper;
        _robotMotion = GetComponent<RobotMotion>() as RobotMotion;
        _robot = transform.Find("Robot");
        _targetPosition = _robot.position;
        //StopRadius += Random.Range(1, 10);
    }

    /*public void CollisionDetected(CollisionObserver collisionObserver)
    {
        //Произошло столкновение с игроком
    }*/

    public void AirCharge(Vector3 direction, Vector3 followObjectDirection)
    {
        float d = direction.magnitude;

        RaycastHit hit;
        if (Physics.Raycast(_robot.position, -Vector3.up, out hit, 100.0f))
        {
            print(hit.distance);
            if (hit.distance >= 18 && d < 100)
            {
                _rigidbody.velocity = new Vector3(0, 0, 0);
                _rigidbody.AddForce((direction + followObjectDirection * d / 200).normalized * 200, ForceMode.Impulse);
            }
        }
    }

    private void Update()
    {
        if (prev_allies_count != npchelper.countNPCAlies)
        {
            prev_allies_count = npchelper.countNPCAlies;
            GameObject[] temporary = GameObject.FindGameObjectsWithTag("NPC Allies");

            followObjects = new Transform[1 + temporary.Length];
            for (int i = 0; i < temporary.Length; ++i)
            {
                followObjects[i] = temporary[i].transform.Find("Robot").transform;
            }

            followObjects[temporary.Length] = GameObject.Find("Robot Player").transform.Find("Robot").transform;



            /*
            GameObject NPC_Allies = GameObject.Find("NPC Allies");
            int temporary = NPC_Allies.transform.childCount;
            followObjects = new Transform[1 + temporary];
            for (int i = 0; i < temporary; ++i)
            {
                followObjects[i] = NPC_Allies.transform.GetChild(i).GetChild(0);
            }

            followObjects[temporary] = GameObject.Find("Robot Player").transform.GetChild(0);
            prev_allies_count = npchelper.countNPCAlies;

            */
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int min_i = 0;

        Vector3 notNormalizedDirection = followObjects[0].position - _robot.position;
        float distance = notNormalizedDirection.magnitude;
        Vector3 direction = notNormalizedDirection.normalized;
        Rigidbody followObjectRB = followObjects[0].gameObject.GetComponentInChildren(typeof(Rigidbody)) as Rigidbody;
        Vector3 followObjectDirection = followObjectRB.velocity;

        for (int i = 1; i < followObjects.Length; ++i)
        {
            Vector3 dir = (followObjects[i].position - _robot.position);
            if (dir.magnitude < distance)
            {
                notNormalizedDirection = dir;
                distance = dir.magnitude;
                min_i = i;
                direction = dir.normalized;
            }
        }

        if (distance < ActivateRadius)
        {
            if (healthHelper.getHealth() < (0.5 * healthHelper.MaxHealth))
            {
                Attack = false;
            }
            else Attack = true;

            // если робот двигался с нитро (speedUp = true) и нитро ещё есть - тратим его, иначе выключаем его и копим до 50
            if (speedUp & nitro_amount > 0)
            {
                nitro_amount -= (float)0.1;
            }
            else
            {
                speedUp = false;
                nitro_amount += (float)0.2;
                if (nitro_amount > 50 || healthHelper.getHealth() < 20) speedUp = true;
            }

            if (Attack)
            {
                jump_cooldown -= 1;

                if (need_charge)
                {
                    _robotMotion.Move(-1 * direction, true);
                    if (distance > 30) need_charge = false;
                }
                else if (jump_cooldown <= 0 && _robotMotion.OnGround && notNormalizedDirection.magnitude < 100)
                {
                    _rigidbody.AddForce(Vector3.up * 15, ForceMode.Impulse);
                }
                else if (jump_cooldown <= 0 && (!Physics.Raycast(_robot.position, -Vector3.up, 20)))
                {
                    AirCharge(notNormalizedDirection, followObjectDirection);
                    jump_cooldown = 500;
                }
                else
                {
                    _robotMotion.Move(direction, speedUp);
                }
            }
            else
            {
                //дадим роботу дополнительное нитро
                nitro_amount = Math.Min(100, nitro_amount + 10);

                float min_distance = 9999999999999;
                int min_index = 0;

                for (int i = 0; i < medicine_cabinets.Length; ++i)
                {
                    float dist = (medicine_cabinets[i].transform.position - _robot.position).magnitude;
                    if (dist < min_distance && medicine_cabinets[i].activeSelf)
                    {
                        min_distance = dist;
                        min_index = i;
                    }
                }

                direction = medicine_cabinets[min_index].transform.position - _robot.position;
                direction = direction.normalized;

                _robotMotion.Move(direction, speedUp);

            }
        }
        else
        {
            print("STOP!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            _robotMotion.Stop();
        }
    }
}