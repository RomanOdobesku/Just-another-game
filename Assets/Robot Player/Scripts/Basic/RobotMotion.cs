using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotMotion : MonoBehaviour
{
    public float MovePower = 50;
    public float AddForceCoefficient = 1;
    public float MaxAngularVelocity = 25;
    public float JumpPower = 25;
    public float AccelerationCoefficient = 2.0f;
    public float BrakingCoefficient = 0.01f;
    public bool UseAddForce = true;
    public bool UseDust;

    [SerializeField] private float Velocity;

    private float _currentMaxAngularVelocity;
    private float _currentMovePower;

    private const float _groundRayLength = 2.5f;

    private Rigidbody _rigidbody;
    private GameObject Dust;
    private Transform _robot;

    [SerializeField]
    private bool _onGround = false;
    private bool _stop = false;
    public bool OnGround
    { 
        set => _onGround = value;
        get => _onGround;
    }

    private ContactPoint _touchPoint;
    public ContactPoint TouchPoint
    {
        set
        {
            _touchPoint = value;
        }
    }

    private Transform _transformCollision;
    public Transform TransformCollision
    {
        set => _transformCollision = value;
        get => _transformCollision;
    }


    private Transform _dust;
    private CustomParticalController _dustController;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Fight")
        {
            if (gameObject.CompareTag("Robot Player"))
            {
                float multiplier;
                multiplier = PlayerPrefs.GetInt("Speed");
                MovePower = MovePower * (1 + multiplier / 5);
            }
        }
        _rigidbody = GetComponentInChildren<Rigidbody>() as Rigidbody;
        _rigidbody.maxAngularVelocity = MaxAngularVelocity;
        _robot = _rigidbody.transform;
        _dust = transform.Find("DustStorm");

        _dustController = _dust.GetComponent<CustomParticalController>();
    }

    private void Update()
    {
        Velocity = _rigidbody.velocity.magnitude;
        if (_stop)
        {
            Move(_rigidbody.velocity * -BrakingCoefficient, false);
        }
    }

    private void FixedUpdate()
    {
        if (UseDust && _onGround && _rigidbody.velocity.magnitude > 5)
        {
            Quaternion rotation = Quaternion.LookRotation(_rigidbody.velocity.normalized, _touchPoint.normal);
            rotation *= Quaternion.AngleAxis(90, Vector3.right);
            rotation *= Quaternion.AngleAxis(-90, Vector3.forward);
            _dust.transform.position = _touchPoint.point + _touchPoint.normal;
            _dust.transform.rotation = rotation;
            _dustController.Enabled = true;
        }
        else
        {
            _dustController.Enabled = false;
            _dust.transform.position = _robot.position;
        }
    }

    public void Move(Vector3 moveDirection, bool speedUp)
    {

        if (speedUp)
        {
            _currentMaxAngularVelocity = MaxAngularVelocity * AccelerationCoefficient;
            _currentMovePower = MovePower * AccelerationCoefficient;
        }
        else
        {
            _currentMaxAngularVelocity = MaxAngularVelocity;
            _currentMovePower = MovePower;
        }
        if (_rigidbody.maxAngularVelocity != _currentMaxAngularVelocity)
            _rigidbody.maxAngularVelocity = _currentMaxAngularVelocity;

        _rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * _currentMovePower);
        if (UseAddForce)
            _rigidbody.AddForce(new Vector3(moveDirection.x, 0, moveDirection.z) * AddForceCoefficient);
        _stop = false;
    }

    public void Jump()
    {
        /*
        if (Physics.Raycast(_robot.position, -Vector3.up, _groundRayLength))
        {
            _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
        */
        if (_onGround)
        {
            _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    public void Stop()
    {
        _stop = true;
    }
}
