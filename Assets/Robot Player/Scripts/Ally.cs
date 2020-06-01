using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        _myRigidbody = GetComponentInChildren<Rigidbody>();
        _robotMotion = GetComponent<RobotMotion>();
        _robot = transform.Find("Robot");
    }

    private void Update()
    {
        if (_attack)
        {
            if (_followObjectT && _followObjectT.gameObject.activeSelf)
            {
                Vector3 predictedPos = _followObjectT.position;
                float distance;
                /*
                if (_followObjectR)
                {
                    distance = Vector3.Scale((_robot.position - _followObjectT.position), new Vector3(1, 0, 1)).magnitude;
                    float time = distance / Vector3.Scale(_myRigidbody.velocity, new Vector3(1, 0, 1)).magnitude;
                    Vector3 dir = _followObjectR.velocity;
                    dir.y = 0;
                    predictedPos = _followObjectT.position + dir * time / 2;
                }
                */

                Vector3 direction = predictedPos - _robot.position;
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
