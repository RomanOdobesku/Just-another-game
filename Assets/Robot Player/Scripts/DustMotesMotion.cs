using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustMotesMotion : MonoBehaviour
{
    public float FollowSpeed = 10;
    public float Radius = 100;

    private Transform _followObject;
    private Vector3 _targetPosition;

    void Start()
    {
        _followObject = transform.parent.Find("Robot");
        _targetPosition = _followObject.position;
    }

    
    void FixedUpdate()
    {
        if ((_targetPosition - _followObject.position).magnitude > Radius)
        {
            _targetPosition = _followObject.position + Random.insideUnitSphere * 10;
        }
        float step = FollowSpeed * Time.deltaTime * (_targetPosition - transform.position).magnitude;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
    }
}
