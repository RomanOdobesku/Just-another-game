using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarHelper : MonoBehaviour
{
    private Transform _nPC;
    public Transform NPC
    {
        get { return _nPC; }
        set
        {
            _nPC = value;
            _HealthHelper = NPC.GetComponent<HealthHelper>();
            _Slider = GetComponentInChildren<Slider>();
            _Slider.maxValue = _HealthHelper.MaxHealth;
        }
    }

    private float _Height = 0;
    public Camera Cam;

    public float Height
    {
        set => _Height = value;
    }

    private Slider _Slider;
    private HealthHelper _HealthHelper;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!NPC)
            return;
        Vector3 position = NPC.position;
        position.y += _Height;
        GetComponent<RectTransform>().position = Cam.WorldToScreenPoint(position);
        if (_Slider)
            _Slider.value = _HealthHelper.Health;
    }

    public void DisableSlider()
    {
        Destroy(_Slider.gameObject);
    }
}

