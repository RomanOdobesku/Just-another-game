using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Text_Helper : MonoBehaviour
{
    public Color Color_help;
    public Text[] texts;
    public int Size_Help_Button=14;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].fontSize = Size_Help_Button;
            texts[i].color = Color_help;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
