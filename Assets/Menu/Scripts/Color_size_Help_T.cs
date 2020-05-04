using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_size_Help_T : MonoBehaviour
{
    public Vector4 _Color_Help = new Vector4(1, 175 / 255f, 35 / 255f, 1);
    public int Size = 32;
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].fontSize = Size;
            texts[i].color = new Color(_Color_Help.x, _Color_Help.y, _Color_Help.z, _Color_Help.w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
