using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarHelper : MonoBehaviour
{
    
    public Camera Camera;
    public float distanceRendering = 500;

    private Transform _NPC;
    private float _heightOffset = 0;
    private RectTransform _rectTransform;

    private Collider _robotCollider;

    private Slider _slider;

    private GameObject robot;
    public Transform NPC
    {
        get => _NPC;
        set
        {
            _NPC = value;
            robot = value.gameObject;
        }
    }

    public float HeightOffset
    {
        set => _heightOffset = value;
    }

    public float MaxHealth
    {
        set
        {
            if (!_slider)
            {
                _slider = GetComponentInChildren<Slider>() as Slider;
            }
            _slider.maxValue = value;
        }
    }

    public Camera _Camera
    {
        set => Camera = value;
    }

    public Collider RobotCollider
    {
        set => _robotCollider = value;
    }

    public float Health
    {
        set
        {
            if (_slider)
                _slider.value = value;
        }
    }
    
    void Start()
    {
        if (Camera == null)
        {
            Camera = Camera.main;
        }
        _rectTransform = GetComponent<RectTransform>() as RectTransform;
    }

    void FixedUpdate()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera);
        if (!NPC)
            return;
        Vector3 position = NPC.position;
        position.y += _heightOffset;
        Vector3 direction = Camera.transform.position - (NPC.position/* + Vector3.up * 3*/);
        float distance = direction.magnitude;
        RaycastHit hit;
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        if (distance > distanceRendering
            || !GeometryUtility.TestPlanesAABB(planes, _robotCollider.bounds)
            || Physics.SphereCast(Camera.transform.position, 1, direction, out hit, Math.Max(0, distance - 10), layerMask))
            Hide();
        else
            Show();      
        _rectTransform.position = Camera.WorldToScreenPoint(position);
    }

    void Hide()
    {
        _slider.gameObject.SetActive(false);
    }

    void Show()
    {
        _slider.gameObject.SetActive(true);
    }

    public void DisableSlider()
    {
        Destroy(gameObject);
    }
}

