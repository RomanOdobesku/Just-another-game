using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_main_menu : MonoBehaviour
{
    public Vector4 _Color_main_menu=new Vector4(1,175/255f,35/255f,1);
    public int Size = 48;
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].fontSize = Size;
            texts[i].color = new Color(_Color_main_menu.x, _Color_main_menu.y, _Color_main_menu.z, _Color_main_menu.w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
