using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_Panel : MonoBehaviour
{
    public GameObject MyDoor;
    //Text OpenDoor;
    public Text OpenDoor;
    Door door;
    bool inTrigger;
    // Start is called before the first frame update
    void Start()
    {
        //Transform[] transforms;
        //transforms = GameObject.Find("Canvas").transform.GetComponentsInChildren<Transform>();
        //foreach (Transform transform in transforms)
        //{
        //    if (transform.gameObject.name == "Open Door")
        //    {
        //        OpenDoor = transform.gameObject;
        //        Debug.Log(OpenDoor.gameObject.name.ToString());
        //        OpenDoor.gameObject.SetActive(false);
        //    }
        //}
        door = MyDoor.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                door.speed = 30;
                door.go = 1;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.CompareTag("Robot Player"))
        {
            OpenDoor.gameObject.SetActive(false);
            inTrigger = false;
        };
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Robot Player"))
        {
            OpenDoor.gameObject.SetActive(true);
            inTrigger = true;
        };
    }
}
