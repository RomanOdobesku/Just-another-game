using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public GameObject UsingRadio;
    private bool InTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
                UsingRadio.SetActive(false);
                PlayerPrefs.SetInt("MusicBoss", 1); //1 значит новая музыка
                PlayerPrefs.Save();
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            InTrigger = true;
            UsingRadio.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            InTrigger = false;
            UsingRadio.SetActive(false);
        }
    }
}
