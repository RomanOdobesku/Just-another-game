
using UnityEngine;
using System;

public class RobotPlayer : MonoBehaviour
{
    public Robot.HealthSettings Health = new Robot.HealthSettings();
    public Robot.MoveSettings Move = new Robot.MoveSettings();
    public Robot.CameraSettings Camera = new Robot.CameraSettings();

    private HealthHelper _HealthHelper;
    private RobotBall _RobotBall;
    private CameraFollow _CameraFollow;
    private CameraCollision _CameraCollision;


    private void Start()
    {
        _HealthHelper = gameObject.GetComponentInChildren<HealthHelper>() as HealthHelper;
        _RobotBall = gameObject.GetComponentInChildren<RobotBall>() as RobotBall;
        _CameraFollow = gameObject.GetComponentInChildren<CameraFollow>() as CameraFollow;
        _CameraCollision = gameObject.GetComponentInChildren<CameraCollision>() as CameraCollision;

        _HealthHelper.Init = Health;
        _RobotBall.Init = Move;
        _CameraFollow.Init = Camera;
        _CameraCollision.Init = Camera;
    }
}
