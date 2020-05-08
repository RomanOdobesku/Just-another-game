using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message_Save : MonoBehaviour
{
    public Image image;
    public Text text;
    public float T_Static = 2;
    public float T_Vanish = 1;
    float res;
    Color color_I,color_T;

    // Start is called before the first frame update
    void Start()
    {

        color_I = image.color;
        color_T = text.color;
    }
    float _Timer;
    // Update is called once per frame
    void Update()
    {
        if (_Timer >= T_Vanish)
        {
            _Timer -= Time.deltaTime;
        }
        if (_Timer <= T_Vanish && _Timer>=0)
        {
            _Timer -= Time.deltaTime;
            res = 1-(1+Mathf.Cos(Mathf.PI*_Timer))/2;
            //res = (one - 1)* (one - 1)*(-1) + 1;
            
            image.color = new Color(color_I.r, color_I.g, color_I.b, res);
            text.color = new Color(color_T.r, color_T.g, color_T.b, res);

        }
        if (_Timer < 0)
        {
            image.gameObject.SetActive(false);
        }
    }
    public void Save()
    {

        _Timer = T_Static;
        image.gameObject.SetActive(true);
        image.color = color_I;
        text.color = color_T;
    }

}
