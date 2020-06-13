using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserInputController : MonoBehaviour
{
    public Camera Camera;

    public Ally[] Allies = new Ally[4];

    public bool controlAllies = false;

    private RobotMotion _robotMotion;
    private Vector3 _moveDirection;
    private bool _jump;
    private bool _speedUp;

    private bool _setFollowObject = false;
    private bool _setAlly = false;

    private CameraController _cameraController;
    private AllyMenu _allyMenu;

    private Vector2 _mouseMove;
    private Vector2 _pos;

    private int _allyIndex = 0;

    void Start()
    {
        _robotMotion = GetComponent<RobotMotion>() as RobotMotion;

        if (Camera == null)
        {
            Camera = Camera.main;
        }

        _cameraController = gameObject.GetComponent<CameraController>();
        _allyMenu = GameObject.Find("Canvas").transform.Find("Ally_Panel").GetComponent<AllyMenu>();
    }

    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");
        _jump = Input.GetButton("Jump");
        _speedUp = Input.GetButton("Fire3");

        Vector3 cameraDirection = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized;
        _moveDirection = (forward * cameraDirection + sideways * Camera.transform.right).normalized;

        UpdateState();

        UpdateAllyMenu();
        CheckTarget();
    }

    private void FixedUpdate()
    {
        if (_moveDirection.magnitude != 0)
            _robotMotion.Move(_moveDirection, _speedUp);
        if (_jump)
            _robotMotion.Jump();
    }

    void UpdateAllyMenu()
    {
        if (_allyMenu)
            _allyMenu.Active = _setAlly;
        if (_setAlly && controlAllies)
        {
            _mouseMove.x = Input.GetAxis("Mouse X");
            _mouseMove.y = Input.GetAxis("Mouse Y");


            _pos += _mouseMove;
            
            

            if (_pos.magnitude > 10)
            {
                float angle = Mathf.Atan2(_pos.normalized.x, _pos.normalized.y) * Mathf.Rad2Deg;
                if (-45 <= angle && angle < 45)
                    _allyIndex = 0;
                else if (45 <= angle && angle < 135)
                    _allyIndex = 1;
                else if (135 <= angle || angle < -135)
                    _allyIndex = 2;
                else
                    _allyIndex = 3;
                _allyMenu.ActiveItem(_allyIndex);
            } 
            else
            {
                _allyMenu.DisableItems();
            }

        }
    }

    void CheckTarget()
    {
        if(_setFollowObject && controlAllies)
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
                    bool all = false;
                    if (Input.GetMouseButton(1))
                        all = true;
                    Transform transform = hit.transform;
                    Transform parent = transform.parent;

                    if (!(parent && (parent.CompareTag("NPC Elite") || parent.CompareTag("NPC Usual")) 
                        || transform.CompareTag("Medicine cabinet")))
                        transform = null;
                    if (transform)
                    {
                        Debug.Log("attack");
                        
                        if (all)
                            foreach (Ally i in Allies)
                                i.GoAttack(transform);
                        else
                            Allies[_allyIndex].GoAttack(transform);
                    } else
                    {
                        Debug.Log("patrol");
                        if (all)
                            foreach (Ally i in Allies)
                                i.GoPatrol(hit.point);
                        else
                            Allies[_allyIndex].GoPatrol(hit.point);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.B) && controlAllies)
        {
            if (Input.GetMouseButton(1))
            {
                foreach (Ally i in Allies)
                    i.GoBack();
            } else
            {
                Allies[_allyIndex].GoBack();
            } 
        }
    }

    void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Escape)
            || (Input.GetKeyDown(KeyCode.LeftControl) && !_setAlly && controlAllies))
        {
            _cameraController.RotateCamera = false;
            _cameraController.LockCursor = false;
        }

        if ((!Input.GetKey(KeyCode.Escape) && Input.GetMouseButtonDown(0) && !_setFollowObject)
            || (!Input.GetKey(KeyCode.LeftControl) && _setFollowObject && controlAllies))
        {
            _cameraController.RotateCamera = true;
            _cameraController.LockCursor = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !_setFollowObject && controlAllies)
            _cameraController.RotateCamera = false;

        if (Input.GetKeyUp(KeyCode.LeftAlt) && _setAlly && controlAllies)
            _cameraController.RotateCamera = true;

        if ((Input.GetKeyDown(KeyCode.LeftAlt)
            || Input.GetKeyDown(KeyCode.LeftControl)) && controlAllies)
            _cameraController.SlowDown = true;

        if ((!Input.GetKey(KeyCode.LeftAlt)
            && !Input.GetKey(KeyCode.LeftControl)) && controlAllies)
            _cameraController.SlowDown = false;

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !_setFollowObject && controlAllies)
        {
            _pos = Vector2.zero;
            _setAlly = true;
        }

        if (_setAlly && Input.GetKeyUp(KeyCode.LeftAlt) && controlAllies)
            _setAlly = false;

        if (Input.GetKeyDown(KeyCode.LeftControl) && !_setAlly && controlAllies)
            _setFollowObject = true;

        if (_setFollowObject && Input.GetKeyUp(KeyCode.LeftControl) && controlAllies)
            _setFollowObject = false;
    }
}
