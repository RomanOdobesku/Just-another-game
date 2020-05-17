using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform FollowObject;
    public bool Attack = true;
    public float StopRadius = 25;

    private RobotMotion _robotMotion;
    private Transform _robot;
    private bool _moveToRobot = true;
    private Vector3 _targetPosition;

    void Start()
    {
        _robotMotion = GetComponent<RobotMotion>() as RobotMotion;
        _robot = transform.Find("Robot");
        _targetPosition = _robot.position;
        StopRadius += Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = FollowObject.position - _robot.position;
        float distance = direction.magnitude;
        direction = direction.normalized;

        if (Attack)
        {
            if (!_moveToRobot)
                direction *= -1;
            _robotMotion.Move(direction, _moveToRobot);
            if (_moveToRobot && distance < 5)
                _moveToRobot = false;
            else if (!_moveToRobot && distance > 100)
                _moveToRobot = true;
        } else
        {
            if (distance > StopRadius)
                _robotMotion.Move(direction * Mathf.Lerp(0, 1, distance / 200), true);
            else
                _robotMotion.Stop();
        }
    }
}
