﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class KepperFollow : MonoBehaviour
{
    public Transform[] followObjects;
    public float ActivateRadius = Mathf.Infinity;
    public int _state;
    public float jump_cooldown = 100;
    public float speed;

    private Rigidbody[] rigidbodiesFollowObjects;
    private RobotMotion _robotMotion;
    private Transform _robot;
    private HealthHelperMainEnemy _health;
    private Rigidbody _mRigidbody;
    private bool _moveToRobot = true;
    [SerializeField]
    private bool _isWasHit = false;
    [SerializeField]
    private int indexTarget;

    void Start()
    {
        _mRigidbody = transform.GetComponentInChildren<Rigidbody>();
        _health = GetComponent<HealthHelperMainEnemy>();
        _state = _health.State;
        _robotMotion = GetComponent<RobotMotion>();
        _robot = transform.Find("Robot");
        rigidbodiesFollowObjects = new Rigidbody[followObjects.Length];
        for(int i = 0; i < followObjects.Length; ++i)
        {
            Transform obj = followObjects[i];
            if (obj)
            {
                Rigidbody rigidbody = obj.GetComponentInChildren<Rigidbody>();
                rigidbodiesFollowObjects[i] = rigidbody;
            } else
            {
                rigidbodiesFollowObjects[i] = null;
            }
        }
        indexTarget = 0;
    }

    public void AirCharge(Vector3 direction, Vector3 followObjectDirection)
    {
        float d = direction.magnitude;

        RaycastHit hit;
        if (Physics.Raycast(_robot.position, -Vector3.up, out hit, 100.0f))
        {
            print(hit.distance);
            if (hit.distance >= 33 && d < 100)
            {
                _mRigidbody.velocity = new Vector3(0, 0, 0);
                _mRigidbody.AddForce((direction + followObjectDirection * d / 200).normalized * 200, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        int i = GetFollowObjectIndex();
        Transform followT = followObjects[i];
        Rigidbody followR = rigidbodiesFollowObjects[i];
        Vector3 myVelocity = _mRigidbody.velocity;
        speed = myVelocity.magnitude;
        if (followT)
        {
            jump_cooldown -= 1;
            if (_robotMotion.TransformCollision == followT) 
            {
                _moveToRobot = false;
                _isWasHit = true;
            }
            Vector3 targetPosition = followT.position;
            Vector3 myPosition = _robot.position;
            Vector3 direction = targetPosition - myPosition;
            Vector3 notNormalizedDirection = direction;
            float distance = direction.magnitude;
            if (followR)
            {

                float velProjection = Vector3.Dot(direction, myVelocity) / direction.magnitude;
                float time = direction.magnitude / velProjection;
                if (time < 0)
                    time = 0;
                Vector3 offset = followR.velocity * time;
                if (offset.magnitude < 50)
                    targetPosition += offset;
                direction = targetPosition - myPosition;
            }
            float angle = Vector3.Angle(myVelocity, direction);
            if (angle < 90)
            {
                Quaternion quaternion = Quaternion.AngleAxis((float)(Math.Sqrt(angle) * Math.Sqrt(90)), Vector3.Cross(myVelocity, direction));
                direction = quaternion * direction;
            }
            direction = direction.normalized;

            _state = _health.State;
            if (distance < ActivateRadius)
            {
                if (!_moveToRobot)
                {
                    _robotMotion.Move(-1 * direction, true);
                    if (distance > 100)
                        _moveToRobot = true;

                }
                else if (jump_cooldown <= 0 && _robotMotion.OnGround && distance < 100 && _state > 1)
                    _mRigidbody.AddForce(Vector3.up * 70, ForceMode.Impulse);
                else if (jump_cooldown <= 0 && (!Physics.Raycast(_robot.position, -Vector3.up, 35)) && _state > 1)
                {
                    AirCharge(notNormalizedDirection, followR.velocity);
                    jump_cooldown = 500;
                }
                else
                {
                    _robotMotion.Move(direction, _state > 0);
                }
            }
        }
        else
        {
            _robotMotion.Stop();
        }
    }

    private int GetFollowObjectIndex()
    {
        if (_isWasHit && UnityEngine.Random.Range(0, 100) > 95 || !followObjects[indexTarget])
        {
            _isWasHit = false;
            float minDistance = float.MaxValue;
            int tmpIndex = indexTarget;
            for (int i = 0; i < followObjects.Length; ++i)
            {
                float distance = (followObjects[i].position - transform.position).magnitude;
                if (followObjects[i] && distance < minDistance && i != indexTarget)
                {
                    minDistance = distance;
                    tmpIndex = i;
                }
            }
            indexTarget = tmpIndex;
        }
        return indexTarget;
    }
}
