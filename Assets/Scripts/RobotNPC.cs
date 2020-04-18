using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RobotNPC : MonoBehaviour
{

    public Camera Cam;

    public Robot.HealthSettings Health = new Robot.HealthSettings();
    public Robot.MoveSettings Move = new Robot.MoveSettings();

    private HealthHelper _HealthHelper;
    private RobotBall _RobotBall;

    private void Start()
    {
        _HealthHelper = gameObject.GetComponentInChildren<HealthHelper>() as HealthHelper;
        _RobotBall = gameObject.GetComponentInChildren<RobotBall>() as RobotBall;

        _HealthHelper.Init = Health;
        _RobotBall.Init = Move;
        if (Cam == null)
        {
            Cam = GameObject.FindGameObjectsWithTag("Player Camera")[0].GetComponent<Camera>();
            if (Cam == null)
                Cam = Camera.main;
        }
        UIHealthBarHelper _UIHealthBarHelper = GetComponentInChildren<UIHealthBarHelper>() as UIHealthBarHelper;
        if (_UIHealthBarHelper == null)
            print("_UIHealthBarHelper null");
        _UIHealthBarHelper.InitCam = Cam;
    }
}
