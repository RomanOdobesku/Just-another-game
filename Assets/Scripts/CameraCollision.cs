using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField] private float MinDistance = 1.0f;
    [SerializeField] private float TargetDistance = 25.0f;
    [SerializeField] private float MaxDistance = 50.0f;
    [SerializeField] private float Smooth = 10.0f;
    [SerializeField] private Vector3 DollyDirection;
    public Vector3 DollyDirectionAdjusted;
    [SerializeField] private float Distance;

    public RobotPlayer.CameraSettings Init
    {
        set
        {
            MinDistance = value.MinDistance;
            TargetDistance = value.TargetDistance;
            MaxDistance = value.MaxDistance;
            Smooth = value.Smooth;
        }
    }

    public float AddMaxDistance
    {
        set
        {
            TargetDistance += value;
            TargetDistance = Mathf.Clamp(TargetDistance, MinDistance, MaxDistance);
        }

        get
        {
            return TargetDistance;
        }
    }

    private void Awake()
    {
        DollyDirection = transform.localPosition.normalized;
        Distance = transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 desireCameraPosition = transform.parent.TransformPoint(DollyDirection * TargetDistance) + DollyDirectionAdjusted;
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desireCameraPosition, out hit))
        {
            Distance = Mathf.Clamp(hit.distance * 0.85f, MinDistance, TargetDistance);
        } else
        {
            Distance = TargetDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, DollyDirection * Distance, Time.deltaTime * Smooth);
            
    }
}
