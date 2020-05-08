using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roma : MonoBehaviour
{
    public Image image1;
    public Image image2;
    // Start is called before the first frame update
    void Start()
    {
        image1.fillAmount = 1;
        image2.fillAmount = 0;
    }
    float Timer=5;
    // Update is called once per frame
    void Update()
    {
        if (Timer>0)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            image1.fillAmount -= Time.deltaTime / 5;
            image2.fillAmount += Time.deltaTime / 5;
        }
        
    }
}
