using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RobotMotion : MonoBehaviour
{
    public float MovePower = 50;
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

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>() as Rigidbody;
        _rigidbody.maxAngularVelocity = MaxAngularVelocity;
        _robot = _rigidbody.transform;
    }

    private void Update()
    {
        Velocity = _rigidbody.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        if (UseDust && _rigidbody.velocity.magnitude > 5)
        {
            Quaternion rotation = Quaternion.FromToRotation(transform.forward, _rigidbody.velocity.normalized);
            GameObject dust = Instantiate(Dust, _rigidbody.position, rotation);
            Destroy(dust, 0.1f);
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
    }

    public void Jump()
    {
        if (Physics.Raycast(_robot.position, -Vector3.up, _groundRayLength))
        {
            _rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }
}
