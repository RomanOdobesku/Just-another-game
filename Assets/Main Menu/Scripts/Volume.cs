using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value= PlayerPrefs.GetFloat("Volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        PlayerPrefs.Save();
    }
}
