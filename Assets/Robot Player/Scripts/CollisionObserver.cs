using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObserver : MonoBehaviour
{

    private HealthHelper _healthHelper;
    private RobotMotion _robotMotion;

    void Start()
    {
        _healthHelper = transform.parent.GetComponent<HealthHelper>() as HealthHelper;
        _robotMotion = transform.parent.GetComponent<RobotMotion>() as RobotMotion;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        GameObject parent = other.transform.parent.gameObject;
        if (other.CompareTag("Robot"))
            _healthHelper.GetRobotHit(collision);
        else if (other.CompareTag("Lava"))
            _healthHelper.Lava = true;
        else if (other.CompareTag("Terrain") || parent && parent.CompareTag("Terrain"))
        {
            _robotMotion.OnGround = true;
            _robotMotion.TouchPoint = collision.GetContact(0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;
        GameObject parent = other.transform.parent.gameObject;
        if (other.CompareTag("Terrain") || parent && parent.CompareTag("Terrain"))
        {
            _robotMotion.TouchPoint = collision.GetContact(0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;
        GameObject parent = other.transform.parent.gameObject;
        if (other.CompareTag("Lava"))
            _healthHelper.Lava = false;
        else if (other.CompareTag("Terrain") || parent && parent.CompareTag("Terrain"))
            _robotMotion.OnGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine cabinet"))
        {
            _healthHelper.GetRepairKit();
        }
    }
}
