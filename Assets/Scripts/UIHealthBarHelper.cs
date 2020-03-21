using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarHelper : MonoBehaviour
{
    Transform _nPC;
    public Transform NPC
    {
        get { return _nPC; }
        set
        {
            _nPC = value;
            _healthHelper = NPC.GetComponent<HealthHelper>();
            _slider = GetComponentInChildren<Slider>();
            _slider.maxValue = _healthHelper.MaxHealth;
        }
    }

    public float Height
    {
        set
        {
            _height = value;
        }
    }

    Slider _slider;
    HealthHelper _healthHelper;
    public float _height = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!NPC)
            return;
        Vector3 position = NPC.position;
        position.y += _height;
        print(position);
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(position);
        if (_slider)
            _slider.value = _healthHelper.Health;
    }

    public void DisableSlider()
    {
        Destroy(_slider.gameObject);
    }
}

