using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improv_Menu_Position : MonoBehaviour
{
    
    void Start()
    {
        float width = (Screen.width- 500)/2;
        GameObject button = GameObject.Find("No_B");
        button.transform.localPosition = new Vector3(0- width, button.transform.localPosition.y);
        button = GameObject.Find("Yes_B");
        button.transform.localPosition = new Vector3(width, button.transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
