using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Color_Button : MonoBehaviour
{
    public Text text;
    Color color_beg;
    Color color_end;
    private Color_Text_Button Color_Text_Buttons;
    private int Size;
    GameObject canvas;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        Color_Text_Buttons = canvas.GetComponent<Color_Text_Button>();
        Size = Color_Text_Buttons.Size_Button;
        color_beg = Color_Text_Buttons.color_beg;
        color_end = Color_Text_Buttons.color_end;
        text.fontSize = Size;
        text.color = color_beg;
    }

    
    void Update()
    {
        
    }
    public void OnPointerEnter()
    {
        text.color = color_end;
    }
    public void OnPointerEnter(BaseEventData data)
    {
        text.color = color_end;
    }
    public void OnPointerExit()
    {
        text.color = color_beg;
    }
    public void OnPointerExit(BaseEventData data)
    {
        text.color = color_beg;
    }
}
