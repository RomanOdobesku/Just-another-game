using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColusionObserverMainEnemy : MonoBehaviour
{
    private HealthHelperMainEnemy _healthHelperMainEnemy;
    private RobotMotion _robotMotion;

    void Start()
    {
        _healthHelperMainEnemy = transform.parent.GetComponent<HealthHelperMainEnemy>();
        _robotMotion = transform.parent.GetComponent<RobotMotion>() as RobotMotion;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        GameObject parent = other.transform.parent.gameObject;
        if (other.CompareTag("Robot") || other.CompareTag("Robot Player"))
            _healthHelperMainEnemy.GetRobotHit(collision);
        else if (other.CompareTag("Terrain") || parent && parent.CompareTag("Terrain"))
        {
            _robotMotion.OnGround = true;
            _robotMotion.TouchPoint = collision.GetContact(0);
            
        }
        _robotMotion.TransformCollision = collision.transform;
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
         if (other.CompareTag("Terrain") || parent && parent.CompareTag("Terrain"))
            _robotMotion.OnGround = false;
    }
}
