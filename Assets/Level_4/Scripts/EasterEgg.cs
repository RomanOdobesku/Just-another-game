using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public string MyName;
    public GameObject StartVideo;
    private bool InTrigger=false;
    private TV tv;
    // Start is called before the first frame update
    void Start()
    {
        tv = GameObject.Find("TV").GetComponent<TV>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (MyName == "Roma")
                {
                    tv.StartVideoRoma();
                }
                if (MyName == "Egor")
                {
                    tv.StartVideoEgor();
                }
                if (MyName == "Any")
                {
                    tv.StartVideoAny();
                }
                if (MyName == "Sasha")
                {
                    tv.StartVideoSasha();
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            InTrigger = true;
            StartVideo.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            InTrigger = false;
            StartVideo.SetActive(false);
        }
    }
}
