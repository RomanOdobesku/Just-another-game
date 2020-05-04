using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform FollowObject;

    private RobotMotion _robotMotion;
    private Transform _robot;
    private bool _moveToRobot = true;
    private Vector3 _targetPosition;

    void Start()
    {
        _robotMotion = GetComponent<RobotMotion>() as RobotMotion;
        _robot = transform.Find("Robot");
        _targetPosition = _robot.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _robot.position - FollowObject.position;
        if (_moveToRobot)
            direction *= -1;
        _robotMotion.Move(direction.normalized, _moveToRobot);
        float distance = direction.magnitude;

        if (_moveToRobot && distance < 5)
            _moveToRobot = false;
        else if (!_moveToRobot && distance > 100)
            _moveToRobot = true;
    }
}
