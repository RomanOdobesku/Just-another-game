using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Transform FollowObject;
    public bool need_charge = false;
    private HealthHelper healthHelper;
    private Transform[] followObjects = new Transform[5];
    bool Attack = true;
    //public float StopRadius = 25;
    public float ActivateRadius = Mathf.Infinity;

    float nitro_amount = 100;

    private RobotMotion _robotMotion;
    private Transform _robot;
    private bool speedUp = true;
    private Vector3 _targetPosition;
    GameObject[] medicine_cabinets;

    void Start()
    {
        GameObject[] temporary = GameObject.FindGameObjectsWithTag("NPC Allies"); 

        for (int i = 0; i < 4; ++i)
        {
            followObjects[i] = temporary[i].transform.Find("Robot").transform;
        }

        followObjects[4] = GameObject.Find("Robot Player").transform.Find("Robot").transform;

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
    // Update is called once per frame
    void Update()
    {
        int min_i = 0;

        Vector3 direction = followObjects[0].position - _robot.position;
        float distance = direction.magnitude;
        direction = direction.normalized;

        for (int i = 1; i < followObjects.Length; ++i)
        {
            Vector3 dir = (followObjects[i].position - _robot.position);
            if (dir.magnitude < distance)
            {
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
                if (need_charge)
                {
                    _robotMotion.Move(-1 * direction, true);
                    if (distance > 30) need_charge = false;
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
            _robotMotion.Stop();
        }
    }
}