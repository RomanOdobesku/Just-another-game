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
    // Update is called once per frame
    void Update()
    {
    }

    public void Save()
    {
        StartCoroutine(GoOut());
        
    }
    private IEnumerator GoOut()
    {
        image.gameObject.SetActive(true);
        image.color = color_I;
        text.color = color_T;
        yield return new WaitForSeconds(T_Static);
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime;
            res = 1 - (1 + Mathf.Cos(Mathf.PI * t)) / 2;
            image.color = new Color(color_I.r, color_I.g, color_I.b, res);
            text.color = new Color(color_T.r, color_T.g, color_T.b, res);
            yield return null;
        }
        image.gameObject.SetActive(false);
        yield return null;
    }
}
