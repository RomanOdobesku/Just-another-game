using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarHelper : MonoBehaviour
{
    
    public Camera Camera;
    public float DistanceRendering = 350;

    private float _heightOffset = 0;
    private VisibleChecker _visibleChecker;
    private RectTransform _rectTransform;
    private Slider _slider;


    public VisibleChecker VisibleChecker
    {
        set => _visibleChecker = value;
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
        if (_visibleChecker)
        {
            Vector3 position = _visibleChecker.transform.position;
            position.y += _heightOffset;
            Vector3 direction = Camera.transform.position - position;
            float distance = direction.magnitude;
            if (distance > DistanceRendering || !_visibleChecker.Visible)
                Hide();
            else
                Show();
            _rectTransform.position = Camera.WorldToScreenPoint(position);
        }
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

