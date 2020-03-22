using System;
using UnityEngine;



public class RobotUserControl : MonoBehaviour
{
    private RobotBall ball; // Reference to the ball controller.

    private Vector3 move;
    // the world-relative desired move direction, calculated from the camForward and user input.

    public Transform cam; // A reference to the main camera in the scenes transform
    private Vector3 camForward; // The current forward direction of the camera
    private bool jump; // whether the jump button is currently pressed
    private bool shift;


    private void Awake()
    {
        // Set up the reference.
        ball = GetComponent<RobotBall>();
    }


    private void Update()
    {
        // Get the axis and jump input.

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");

        // calculate move direction
        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = (v * camForward + h * cam.right).normalized;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            move = (v * Vector3.forward + h * Vector3.right).normalized;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            shift = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            shift = false;
    }


    private void FixedUpdate()
    {
        // Call the Move function of the ball controller
        ball.Move(shift ? move : move * 2, jump);
        jump = false;
    }
}
