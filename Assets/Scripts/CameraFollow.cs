using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float CameraMoveSpeed = 100.0f;
    public GameObject CameraFollowObject;
    [SerializeField] private float MaxAngleY = 90;
    [SerializeField] private float MinAngleY = -90;
    [SerializeField] private float HorizontalSensivity = 150;
    [SerializeField] private float VerticalSensivity = 150;
    [SerializeField] private float MouseWheelSensivity = 1500;
    [SerializeField] private float MouseX;
    [SerializeField] private float MouseY;
    [SerializeField] private float MouseWheel;
    [SerializeField] private float RotationY;
    [SerializeField] private float RotationX;

    [SerializeField] private bool LockCursor = true;

    public RobotPlayer.CameraSettings Init
    {
        set
        {
            CameraMoveSpeed = value.MoveSpeed;
            MaxAngleY = value.MaxAngleY;
            MinAngleY = value.MinAngleY;
            HorizontalSensivity = value.HorizontalSensivity;
            VerticalSensivity = value.VerticalSensivity;
            MouseWheelSensivity = value.MouseWheelSensivity;
            LockCursor = value.LockCursor;
        }
    }

    private bool m_cursorIsLocked = true;

    private CameraCollision cameraCollision;

    private void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        RotationY = rotation.y;
        RotationX = rotation.x;
        cameraCollision = gameObject.GetComponentInChildren<CameraCollision>() as CameraCollision;
    }

    private void Update()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        RotationY += MouseX * HorizontalSensivity * Time.deltaTime;
        RotationX -= MouseY * VerticalSensivity * Time.deltaTime;

        RotationX = Mathf.Clamp(RotationX, MinAngleY, MaxAngleY);

        Quaternion localRotation = Quaternion.Euler(RotationX, RotationY, 0.0f);
        transform.rotation = localRotation;

        MouseWheel = Input.GetAxis("Mouse ScrollWheel");
        cameraCollision.AddMaxDistance = -MouseWheel * MouseWheelSensivity * Time.deltaTime;

        UpdateCursorLock();
    }

    private void LateUpdate()
    {
        Transform target = CameraFollowObject.transform;
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (LockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
