using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Color_Button : MonoBehaviour
{
    public Text text;
    Vector4 color_beg;
    Vector4 color_end;
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
        text.color = new Color(color_beg.x, color_beg.y, color_beg.z, color_beg.w);
    }

    
    void Update()
    {
        
    }
    public void OnPointerEnter()
    {
        text.color = new Color(color_end.x, color_end.y, color_end.z, color_end.w);
    }
    public void OnPointerEnter(BaseEventData data)
    {
        text.color = new Color(color_end.x, color_end.y, color_end.z, color_end.w);
    }
    public void OnPointerExit()
    {
        text.color = new Color(color_beg.x, color_beg.y, color_beg.z, color_beg.w);
    }
    public void OnPointerExit(BaseEventData data)
    {
        text.color = new Color(color_beg.x, color_beg.y, color_beg.z, color_beg.w);
    }
}
