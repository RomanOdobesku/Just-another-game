using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginner : MonoBehaviour
{
    public GameObject Main_Panel;
    public GameObject Begin_Panel;
    public bool ClearAfterStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (ClearAfterStart)
        {
            PlayerPrefs.SetInt("Beginner", 0);
            PlayerPrefs.Save();
        } 
        int begin = PlayerPrefs.GetInt("Beginner", 0);
        if (begin==0)
        {
            Main_Panel.SetActive(false);
            Begin_Panel.SetActive(true);
            PlayerPrefs.SetInt("Beginner", 1);
            PlayerPrefs.Save();
        }
        
        if (ClearAfterStart)
        {
            PlayerPrefs.SetInt("Beginner", 0);
            PlayerPrefs.Save();
        }
    }
    
}
