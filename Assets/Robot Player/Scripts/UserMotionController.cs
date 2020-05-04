using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMotionController : MonoBehaviour
{
    public Camera Camera;

    private RobotMotion _robotMotion;
    private Vector3 _moveDirection;
    private bool _jump;
    private bool _speedUp;

    void Start()
    {
        _robotMotion = GetComponent<RobotMotion>() as RobotMotion;

        if (Camera == null)
        {
            Camera = Camera.main;
        }
    }

    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");
        _jump = Input.GetButton("Jump");
        _speedUp = Input.GetButton("Fire3");

        Vector3 cameraDirection = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized;
        _moveDirection = (forward * cameraDirection + sideways * Camera.transform.right).normalized;
    }

    private void FixedUpdate()
    {
        if (_moveDirection.magnitude != 0)
            _robotMotion.Move(_moveDirection, _speedUp);
        if (_jump)
            _robotMotion.Jump();
    }
}
