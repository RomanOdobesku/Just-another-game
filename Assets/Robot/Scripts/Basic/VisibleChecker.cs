using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class VisibleChecker : MonoBehaviour
{
    public float Radius = 1.68f;
    public Camera Cam;
    public Collider Col;

    [SerializeField]
    private bool _visible;
    private float _timer;

    private int _layerMask;
    public bool Visible
    {
        get => _visible;
    }

    private void SetVisible(bool value)
    {
        if (_visible != value)
        {
            if (value && _timer > 0.5f)
            {
                _visible = value;
                _timer = 0;
            }
            else if (!value && _timer > 0.5f)
            {
                _visible = value;
                _timer = 0;
            }
        }
    }

    List<Vector3> points;

    private void Start()
    {
        points = new List<Vector3>();
        points.Add(new Vector3(0, Radius, 0));
        points.Add(new Vector3(0, -Radius, 0));
        points.AddRange(getPointsOnCircle(4, Radius * Mathf.Cos(45)));
        points.AddRange(getPointsOnCircle(4, -Radius * Mathf.Cos(45)));
        points.AddRange(getPointsOnCircle(8, 0));
        if (!Cam)
            Cam = Camera.main;
        if (!Col)
        {
            Col = GetComponent<SphereCollider>();
        }

        _layerMask = 1 << 2;
        _layerMask |= 1 << 10;
        _layerMask = ~_layerMask;
    }
    
    private Vector3[] getPointsOnCircle(int n, float h)
    {
        Vector3[] answer = new Vector3[n];
        for(int i = 0; i < n; ++i)
        {
            answer[i] = new Vector3(Radius * Mathf.Cos(360 / n * i), h, Radius * Mathf.Sin(360 / n * i));
        }
        return answer;
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (Cam)
        {
            if (Col)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Cam);
                if (!GeometryUtility.TestPlanesAABB(planes, Col.bounds))
                {
                    SetVisible(false);
                    return;
                } 
                foreach (Vector3 point in points)
                {
                    RaycastHit hit;
                    if (Physics.Linecast(Cam.transform.position, point + transform.position, out hit, _layerMask))
                    {
                        if ((hit.point - transform.position).magnitude < 1.5f * Radius)
                        {
                            SetVisible(true);
                            return;
                        }
                    }
                }
                SetVisible(false);
            }
        }
    }
}
