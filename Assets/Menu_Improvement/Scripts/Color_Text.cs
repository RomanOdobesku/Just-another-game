using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Color_Text : MonoBehaviour
{
    public Text text;
    public Color color_begin;
    public Color color_highlighted;
    public Color color_click;
    Color color_last;
    // Start is called before the first frame update
    void Start()
    {
        text.color = color_begin;
        color_last = color_begin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(BaseEventData data)
    {
        text.color = color_click;
    }
    public void OnPointerUp(BaseEventData data)
    {
        text.color = color_last;
    }
    public void OnPointerEnter(BaseEventData data)
    {
        text.color = color_highlighted;
        color_last = color_highlighted;
    }
    public void OnPointerExit(BaseEventData data)
    {
        text.color = color_begin;
        color_last = color_begin;
    }
}
