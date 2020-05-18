using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Blue_Field : MonoBehaviour
{
    public GameObject NPC_robots;
    bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        NPC_robots.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        GameObject parent = obj.transform.parent.gameObject;
        if ((obj.CompareTag("Robot Player") || parent.CompareTag("Robot Player")) && !Active)
        {
           
           NPC_robots.SetActive(true);
           Active = true;
        }
    }
}
