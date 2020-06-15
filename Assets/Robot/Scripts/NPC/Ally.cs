using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ally : MonoBehaviour
{
    public Transform Player;
    public float StopRadius = 25;

    private Transform _followObjectT;
    private Rigidbody _followObjectR;
    private Vector3 _pos;

    private bool _attack = false;
    private bool _patrol = false;

    private Rigidbody _myRigidbody;

    private RobotMotion _robotMotion;
    private Transform _robot;

    private bool _moveToRobot = true;

    private HealthHelper healthHelper;
    GameObject[] medicine_cabinets;


    private void Start()
    {
        medicine_cabinets = GameObject.FindGameObjectsWithTag("Medicine cabinet");
        healthHelper = GetComponent<HealthHelper>() as HealthHelper;

        _myRigidbody = GetComponentInChildren<Rigidbody>();
        _robotMotion = GetComponent<RobotMotion>();
        _robot = transform.Find("Robot");
    }

    private void Update()
    {
        if (healthHelper.getHealth() <= 20)
        {
            Vector3 direction;
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

            _robotMotion.Move(direction, true);
        }
        else if (_attack)
        {
            if (_followObjectT && _followObjectT.gameObject.activeSelf)
            {
                Vector3 predictedPos = _followObjectT.position;
                float distance;
                Vector3 direction = predictedPos - _robot.position;

                if (_followObjectR)
                {
                    float velProjection = Vector3.Dot(direction, _myRigidbody.velocity) / direction.magnitude;
                    float time = direction.magnitude / velProjection;
                    if (time < 0)
                        time = 0;
                    Vector3 offset = _followObjectR.velocity * time;
                    if (offset.magnitude < 50)
                        predictedPos += offset;
                    direction = predictedPos - _robot.position;
                }
                float angle = Vector3.Angle(_myRigidbody.velocity, direction);
                if (angle < 90)
                {
                    Quaternion quaternion = Quaternion.AngleAxis((float)(Math.Sqrt(angle) * Math.Sqrt(90)), Vector3.Cross(_myRigidbody.velocity, direction));
                    direction = quaternion * direction;
                }
                distance = direction.magnitude;
                direction = direction.normalized;
                if (!_moveToRobot)
                    direction *= -1;
                _robotMotion.Move(direction, _moveToRobot);
                if (_moveToRobot && distance < 5)
                    _moveToRobot = false;
                else if (!_moveToRobot && distance > 100)
                    _moveToRobot = true;
            }
            else
            {
                _attack = false;
            }
        } else if (_patrol)
        {
            Vector3 direction = _pos - _robot.position;
            float distance = direction.magnitude;
            direction = direction.normalized;
            if (distance > StopRadius)
                _robotMotion.Move(direction * Mathf.Lerp(0, 1, distance / 200), true);
            else
                _robotMotion.Stop();
        } else
        {
            Vector3 direction = Player.position - _robot.position;
            float distance = direction.magnitude;
            direction = direction.normalized;
            if (distance > StopRadius)
                _robotMotion.Move(direction * Mathf.Lerp(0, 1, distance / 200), true);
            else
                _robotMotion.Stop();
        }
    }

    public void GoAttack(Transform obj)
    {
        if (obj)
        {
            _patrol = false;
            _attack = true;
            _followObjectT = obj;
            _followObjectR = obj.GetComponent<Rigidbody>();
        }
    }

    public void GoPatrol(Vector3 pos)
    {
        _patrol = true;
        _attack = false;
        _pos = pos;
    }

    public void GoBack()
    {
        _attack = false;
        _patrol = false;
    }

}
