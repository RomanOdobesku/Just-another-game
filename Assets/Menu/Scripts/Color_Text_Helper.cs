using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Text_Helper : MonoBehaviour
{
    public Vector4 Color_help= new Vector4(1, 0.390625f,0,1);
    public Text[] texts;
    public int Size_Help_Button=14;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].fontSize = Size_Help_Button;
            texts[i].color = new Color(Color_help.x, Color_help.y, Color_help.z, Color_help.w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
