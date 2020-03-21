using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxCurrentDistance = 25.0f;
    public float maxDistance = 50.0f;
    public float smooth = 10.0f;
    Vector3 dollyDirection;
    public Vector3 dollyDirectionAdjusted;
    public float distance;

    public float AddMaxDistance
    {
        set
        {
            maxCurrentDistance += value;
            maxCurrentDistance = Mathf.Clamp(maxCurrentDistance, minDistance, maxDistance);
        }

        get
        {
            return maxCurrentDistance;
        }
    }

    private void Awake()
    {
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 desireCameraPosition = transform.parent.TransformPoint(dollyDirection * maxCurrentDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desireCameraPosition, out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.85f, minDistance, maxCurrentDistance);
            print("пересечение");
        } else
        {
            distance = maxCurrentDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);
            
    }
}
