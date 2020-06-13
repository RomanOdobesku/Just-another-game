using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarKeeper : MonoBehaviour
{
    private Slider _slider;

    public float Health
    {
        set
        {
            if (_slider)
                _slider.value = value;
        }
    }
    public float MaxHealth
    {
        set
        {
            if (!_slider)
            {
                _slider = GetComponentInChildren<Slider>();
            }
            _slider.maxValue = value;
        }
    }

    public void Hide()
    {
        if (!_slider)
        {
            _slider = GetComponentInChildren<Slider>();
        }
        _slider.gameObject.SetActive(false);
    }

    public void Show()
    {
        if (!_slider)
        {
            _slider = GetComponentInChildren<Slider>();
        }
        _slider.gameObject.SetActive(true);
    }
}
