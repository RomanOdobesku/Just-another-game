using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObserver : MonoBehaviour
{ 

    private HealthHelper _healthHelper;

    void Start()
    {
        _healthHelper = transform.parent.GetComponent<HealthHelper>() as HealthHelper;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
            _healthHelper.GetRobotHit(collision);
        else if (collision.gameObject.CompareTag("Lava"))
            _healthHelper.Lava = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Repair kit"))
        {
            _healthHelper.GetRepairKit();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
            _healthHelper.Lava = false;
    }
}
