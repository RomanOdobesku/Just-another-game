using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class RobotMotion : MonoBehaviour
{
    public float MovePower = 50;
    public float AddForceCoefficient = 1;
    public float MaxAngularVelocity = 25;
    public float JumpPower = 25;
    public float AccelerationCoefficient = 2.0f;
    public GameObject Dust;
    public bool UseAddForce = true;
    public bool UseDust;

    [SerializeField] private float Velocity;

    private float _currentMaxAngularVelocity;
    private float _currentMovePower;

    private const float _groundRayLength = 2.5f;

    private Rigidbody _rigidbody;

    private Transform _robot;

    private bool _onGround = true;
    public bool OnGround
    {
        set
        {
            _onGround = value;
        }
    }

    private ContactPoint _touchPoint;
    public ContactPoint TouchPoint
    {
        set
        {
            _touchPoint = value;
        }
    }

    private GameObject _dust;
    private CustomParticalController _dustController;
    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>() as Rigidbody;
        _rigidbody.maxAngularVelocity = MaxAngularVelocity;
        _robot = _rigidbody.transform;
        _dust = Instantiate(Dust, Vector3.zero, Quaternion.identity);
        _dustController = _dust.GetComponent<CustomParticalController>();
    }

    private void Update()
    {
        Velocity = _rigidbody.velocity.magnitude;
    }

    private void FixedUpdate()
    {

        if (UseDust && _onGround && _rigidbody.velocity.magnitude > 5)
        {
            _dustController.Enabled = true;
            Quaternion rotation = Quaternion.LookRotation(_rigidbody.velocity.normalized, _touchPoint.normal);
            rotation *= Quaternion.AngleAxis(90, Vector3.right);
            rotation *= Quaternion.AngleAxis(-90, Vector3.forward);
            _dust.transform.position = _touchPoint.point + Vector3.up;
            _dust.transform.rotation = rotation;
        } else
        {
            _dustController.Enabled = false;
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
        _rigidbody.AddForce(new Vector3(moveDirection.x, 0, moveDirection.z) * AddForceCoefficient);
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
}
