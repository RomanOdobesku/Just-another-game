using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_main_menu : MonoBehaviour
{
    public Color _Color_main_menu=new Vector4(1,175/255f,35/255f,1);
    public int Size = 48;
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].fontSize = Size;
            texts[i].color = _Color_main_menu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
