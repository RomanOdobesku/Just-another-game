using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI2_Panel : MonoBehaviour
{
    GameObject Back_B;
    GameObject Save_B;
    // Start is called before the first frame update
    void Start()
    {
        Back_B = GameObject.Find("Back_B");
        Save_B = GameObject.Find("Save_B");
        Back_B.SetActive(false);
        Save_B.SetActive(false);
    }
    public void OK()
    {
        Back_B.SetActive(true);
        Save_B.SetActive(true);
        Destroy(this.gameObject);
    }
 
}
