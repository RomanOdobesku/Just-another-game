using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour
{
    public Camera Camera;
    public GameObject CameraFollowObject;
    public GameObject NPCFollowObject;
    public float CameraFollowSpeed = 100.0f;
    public float HorizontalSensivity = 150;
    public float VerticalSensivity = 150;
    public float MouseWheelSensivity = 1500;
    public float maxAngleY = 90;
    public float MinAngleY = -90;

    public float MinCameraOffset = 1.0f;
    public float MaxCameraOffset = 50.0f;
    public float HeightOffset = 0.0f;
    public float SmoothCameraRotation = 10.0f;

    public bool LockCursor = true;
    public bool NPCControl = true;

    private Vector2 _mouseMove;
    private float _mouseWheel;
    private Vector2 _rotation;
    private float _cameraOffset;
    private bool _cursorIsLocked = true;
    private float _targetCameraOffset = 25.0f;

    private bool _followMe = false;

    private Transform _cameraBase;

    PauseGame _pauseGame;

    void Start()
    {
        _pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();

        _cameraBase = transform.Find("Camera base");
        if (Camera == null)
        {
            Camera = Camera.main;
        }

        Camera.transform.SetParent(_cameraBase);

        Vector3 startRotation = _cameraBase.localRotation.eulerAngles;
        _rotation.x = startRotation.x;
        _rotation.y = startRotation.y;

        Camera.transform.localRotation = Quaternion.identity;

        _followMe = NPCControl;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // rotate camera base
        if (_cursorIsLocked)
        {
            //Time.timeScale = 1;
            //Time.fixedDeltaTime = Time.timeScale * 0.02f;
            _mouseMove.x = Input.GetAxis("Mouse X");
            _mouseMove.y = Input.GetAxis("Mouse Y");
        }
        else
        {
            //Time.timeScale = 0.1f;
            //Time.fixedDeltaTime = Time.timeScale * 0.02f;
            _mouseMove.x = 0;
            _mouseMove.y = 0;
        }


        _rotation.x -= _mouseMove.y * VerticalSensivity * Time.deltaTime;
        _rotation.y += _mouseMove.x * HorizontalSensivity * Time.deltaTime;

        _rotation.x = Mathf.Clamp(_rotation.x, MinAngleY, maxAngleY);

        Quaternion localRotation = Quaternion.Euler(_rotation.x, _rotation.y, 0.0f);
        _cameraBase.rotation = localRotation;

        // change camera offset
        _mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        _targetCameraOffset -= _mouseWheel * MouseWheelSensivity * Time.deltaTime;
        _targetCameraOffset = Mathf.Clamp(_targetCameraOffset, MinCameraOffset, MaxCameraOffset);
        
        UpdateCursorLock();

        if (NPCControl)
        {
            if (_followMe)
            {
                NPCFollowObject.transform.position = CameraFollowObject.transform.position;
            }

            if (!_cursorIsLocked)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    int layerMask = 1 << 1;
                    layerMask = ~layerMask;
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        Debug.DrawLine(hit.point, hit.point + Vector3.up * 100, Color.red, 5);
                        NPCFollowObject.transform.position = hit.point;
                        _followMe = false;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _followMe = true;
            }
        }
        
    }

    private void FixedUpdate()
    {
        // move camera base
        Vector3 targetPosition = CameraFollowObject.transform.position;
        targetPosition.y += HeightOffset;
        float step = CameraFollowSpeed * Time.deltaTime;
        _cameraBase.position = Vector3.MoveTowards(_cameraBase.transform.position, targetPosition, step);
        //_cameraBase.position = targetPosition;

        // current move camera
        Vector3 targetCameraPosition = _cameraBase.position - _cameraBase.forward * _targetCameraOffset;
        RaycastHit hit;
        if (Physics.Linecast(_cameraBase.position, targetCameraPosition, out hit))
        {
            _cameraOffset = Mathf.Clamp(hit.distance * 0.85f, MinCameraOffset, _targetCameraOffset);
        }
        else
        {
            _cameraOffset = _targetCameraOffset;
        }

        Camera.transform.localPosition = Vector3.Lerp(Camera.transform.localPosition
            , Vector3.back * _cameraOffset
            , Time.deltaTime * SmoothCameraRotation);
    }

    public void UpdateCursorLock()
    {
        if (LockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (!_pauseGame.pause)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && NPCControl)
            {
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                _cursorIsLocked = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (Input.GetMouseButtonUp(0) && (!Input.GetKey(KeyCode.LeftControl) || !NPCControl) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                _cursorIsLocked = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }
        //if (_cursorIsLocked)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}
        //else if (!_cursorIsLocked)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
        //Debug.Log(_cursorIsLocked.ToString());
    }
}
