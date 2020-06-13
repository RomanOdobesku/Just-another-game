using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObserver : MonoBehaviour
{

    private HealthHelper _healthHelper;
    private RobotMotion _robotMotion;
    GameObject MedicineCab;

    void Start()
    {
        MedicineCab = GameObject.Find("Medicine cabinet");
        _healthHelper = transform.parent.GetComponent<HealthHelper>() as HealthHelper;
        _robotMotion = transform.parent.GetComponent<RobotMotion>() as RobotMotion;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        Transform parent = other.transform.parent;
        if (parent.CompareTag("Robot Player") || other.CompareTag("NPC Allies"))
        {
            if (transform.parent.gameObject.CompareTag("Enemy"))
            {
                transform.parent.GetComponent<Enemy>().need_charge = true;
            }
            else if (transform.parent.gameObject.CompareTag("NPC Elite"))
            {
                transform.parent.GetComponent<EliteEnemy>().need_charge = true;
            }
        }
        if (other.CompareTag("Robot") || other.CompareTag("Robot Player"))
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
        Transform parent = other.transform.parent;
        if (other.CompareTag("Terrain") || parent && parent.CompareTag("Terrain"))
        {
            _robotMotion.TouchPoint = collision.GetContact(0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;
        Transform parent = other.transform.parent;
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
            other.transform.parent.GetComponent<Medicine>().ToTackMedCab(other.gameObject);
        }
        if (other.gameObject.CompareTag("Field Red"))
        {
            _healthHelper.EnterField();
        }
    }
}
