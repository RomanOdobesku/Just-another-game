using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_NPC_Center : MonoBehaviour
{
    Door door;
    public GameObject NPC_center;
    GameObject[] NPC;

    // Start is called before the first frame update
    void Start()
    {
        door=GameObject.Find("Door 1").GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            door.go = -1;
            NPC_center.gameObject.SetActive(true);
            NPC = GameObject.FindGameObjectsWithTag("Robot");
            Destroy(gameObject);
        };
    }
}
