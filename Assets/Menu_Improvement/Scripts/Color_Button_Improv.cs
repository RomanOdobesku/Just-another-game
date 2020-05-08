using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Color_Button_Improv : MonoBehaviour
{
    public Color color_begin;
    public Color color_highlighted;
    public Color color_click;
    Color color_last;
    public Image _image;


    // Start is called before the first frame update
    void Start()
    {
        _image.color = color_begin;
        color_last = color_begin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(BaseEventData data)
    {
        _image.color = color_click;
    }
    public void OnPointerUp(BaseEventData data)
    {
        _image.color = color_last;
    }
    public void OnPointerEnter(BaseEventData data)
    {
        _image.color = color_highlighted;
        color_last = color_highlighted;
    }
    public void OnPointerExit(BaseEventData data)
    {
        _image.color = color_begin;
        color_last = color_begin;
    }
}
