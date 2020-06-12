using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootTower : MonoBehaviour
{
    public GameObject RebootText;
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
                GameObject.Find("Robot Player").transform.GetChild(0).GetComponent<Game_logic_5>().goScene6();
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            InTrigger = true;
            RebootText.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            InTrigger = false;
            RebootText.SetActive(false);
        }
    }
}
