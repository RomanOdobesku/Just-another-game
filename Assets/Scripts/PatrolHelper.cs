using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolHelper : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public float TimeWaiting = 2;
    public float RadiusOfPoint = 2;

    private bool _MoveForward = true;
    private bool _Waiting = false;
    private int _CurrentIndex = 0;
    private RobotBall _RobotBall;
    private float Timer = 0;




    private void Start()
    {
        _RobotBall = gameObject.GetComponentInChildren<RobotBall>() as RobotBall;
    }

    private void FixedUpdate()
    {
        if (Points.Count <= 0)
            return;

        Transform Target = Points[_CurrentIndex];
        Vector3 Direction = Target.position - _RobotBall.gameObject.transform.position;
        Direction.y = 0;
        float Distance = Direction.magnitude;
        Direction = Direction.normalized;
        Direction = Vector3.Lerp(Vector3.zero, Direction, Mathf.Min(Distance, 10) / 10);
        _RobotBall.Move(Direction, false);

        if (_Waiting)
            Timer += Time.deltaTime;

        if (Distance < RadiusOfPoint)
        {
            if (_Waiting)
            {
                if (Timer >= TimeWaiting)
                {
                    _CurrentIndex += _MoveForward ? 1 : -1;
                    if (_CurrentIndex < 0)
                    {
                        _MoveForward = true;
                        _CurrentIndex = 1;
                    }
                    if (_CurrentIndex >= Points.Count)
                    {
                        _MoveForward = false;
                        _CurrentIndex = Points.Count - 2;
                    }
                    _Waiting = false;
                }
            }
            else
            {
                _Waiting = true;
                Timer = 0;
            }
        }
    }
}
