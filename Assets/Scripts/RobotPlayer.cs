
using UnityEngine;
using System;

public class RobotPlayer : MonoBehaviour
{
    [Serializable]
    public class HealthSettings
    {
        public float MaxHealth = 100; // Max robot's health
        public float Health = 100; // current robot's health
        public int Group = 0; // robot's group (in order to define robot's team)
        public float Height = 3;  // health bar height above the robot
        public float DamagePerSecond = 0.1f; // damage that the robot takes every second.
        public bool DynamicHealthBarCreate = true; // show/hide health bar 
    }

    [Serializable]
    public class MoveSettings
    {
        public float MovePower = 25; // The force added to the ball to move it.
        public float MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        public float JumpPower = 5; // The force added to the ball when it jumps.
        public bool UseTorque = true; // Whether or not to use torque to move the ball.
    }

    [Serializable]
    public class CameraSettings
    {
        public float MoveSpeed = 100; // speed of the camera behind the subject
        public float MaxAngleY = 90; // maximum vertical angle
        public float MinAngleY = -90; // minimum vertical angle
        public float HorizontalSensivity = 150; // horizontal mouse sensitivity
        public float VerticalSensivity = 150; // vertical mouse sensitivity
        public float MouseWheelSensivity = 1500; // scrollWheel mouse sensivity 
        public float MinDistance = 1; // minimum distance from the subject to the camera
        public float TargetDistance = 25; // desired distance from the subject to the camera 
        public float MaxDistance = 50; // maximum distance from the subject to the camera
        public float Smooth = 50; // smoothing camera movement in collisions
        public bool LockCursor = true; // hide/show cursor
    }


    public HealthSettings Health = new HealthSettings();
    public MoveSettings Move = new MoveSettings();
    public CameraSettings Camera = new CameraSettings();

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
