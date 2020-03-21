using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraMoveSpeed = 100.0f;
    public GameObject CameraFollowObject;
    private Vector3 followPos;
    public float clampAngle = 80.0f;
    public float inputSensivityHorizontal = 150.0f;
    public float inputSensivityVertical = 150.0f;
    public float inputSensivityScrollWheel = 150.0f;
    public GameObject CameraObject;
    public GameObject playerObject;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float mouseWheel;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    private CameraCollision cameraCollision;

    private void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotY = rotation.y;
        rotX = rotation.x;
        cameraCollision = gameObject.GetComponentInChildren<CameraCollision>() as CameraCollision;
    }

    private void Update()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputZ = Input.GetAxis("Vertical");
        float inputX = 0;
        float inputZ = 0;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensivityHorizontal * Time.deltaTime;
        rotX -= finalInputZ * inputSensivityVertical * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        cameraCollision.AddMaxDistance = -mouseWheel * inputSensivityScrollWheel * Time.deltaTime;

        UpdateCursorLock();
    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObject.transform;
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
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
