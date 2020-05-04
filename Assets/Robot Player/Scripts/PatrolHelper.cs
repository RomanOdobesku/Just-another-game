using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolHelper : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public float TimeWaiting = 2;
    public float RadiusOfPoint = 2;

    private bool _moveForward = true;
    private bool _waiting = false;
    private int _currentIndex = 0;
    private RobotMotion _robotMotion;
    private float _timer = 0;

    private Transform _robot;




    private void Start()
    {
        _robotMotion = GetComponent<RobotMotion>() as RobotMotion;
        _robot = transform.Find("Robot");
    }

    private void FixedUpdate()
    {
        if (Points.Count <= 0)
            return;

        Transform Target = Points[_currentIndex];
        Vector3 Direction = Target.position - _robot.position;
        Direction.y = 0;
        float Distance = Direction.magnitude;
        Direction = Direction.normalized;
        Direction = Vector3.Lerp(Vector3.zero, Direction, Mathf.Min(Distance, 10) / 10);
        _robotMotion.Move(Direction, false);

        if (_waiting)
            _timer += Time.deltaTime;

        if (Distance < RadiusOfPoint)
        {
            if (_waiting)
            {
                if (_timer >= TimeWaiting)
                {
                    _currentIndex += _moveForward ? 1 : -1;
                    if (_currentIndex < 0)
                    {
                        _moveForward = true;
                        _currentIndex = 1;
                    }
                    if (_currentIndex >= Points.Count)
                    {
                        _moveForward = false;
                        _currentIndex = Points.Count - 2;
                    }
                    _waiting = false;
                }
            }
            else
            {
                _waiting = true;
                _timer = 0;
            }
        }
    }
}
