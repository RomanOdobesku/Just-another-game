using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject left_door;
    Vector3 beg_left;
    public GameObject end_left;
    public GameObject right_door;
    Vector3 beg_right;
    public GameObject end_right;
    public int go = -1;
    public float speed = 2;
    public GameObject Wall;
    public GameObject Rock_1;
    public GameObject Rock_2;
    public GameObject Rock_3;
    public GameObject NPC_center;
    GameObject[] NPC;
    bool Active_NPC = false;
    // Start is called before the first frame update
    void Start()
    {
        beg_left = left_door.transform.position;
        beg_right = right_door.transform.position;
        Rock_1.gameObject.SetActive(true);
        Rock_2.gameObject.SetActive(false);
        Rock_3.gameObject.SetActive(false);
        NPC_center.gameObject.SetActive(false);
    }
    
    void Update()
    {
        
       // Debug.Log(count_NPC.ToString());
        if (go == 1)
        {
            left_door.transform.position = Vector3.MoveTowards(left_door.transform.position, end_left.transform.position, Time.deltaTime * speed);
            right_door.transform.position = Vector3.MoveTowards(right_door.transform.position, end_right.transform.position, Time.deltaTime * speed);
        }
        if (go == -1)
        {
            left_door.transform.position = Vector3.MoveTowards(left_door.transform.position, beg_left, Time.deltaTime * speed);
            right_door.transform.position = Vector3.MoveTowards(right_door.transform.position, beg_right, Time.deltaTime * speed);
        }
        if (Active_NPC)
        {
            int count_NPC = NPC.Length;
            foreach (GameObject NPC_r in NPC)
            {

                if (NPC_r.gameObject == null)
                    count_NPC--;
            }
            if (count_NPC == 0)
            {
                go = -1;
                Wall.SetActive(false);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        GameObject parent = obj.transform.parent.gameObject;
        if (obj.CompareTag("Robot Player") || parent.CompareTag("Robot Player"))
        {
            //Wall.SetActive(true);
            go = 1;
            Rock_1.gameObject.SetActive(false);
            Rock_2.gameObject.SetActive(true);
            Rock_3.gameObject.SetActive(true);
            NPC_center.gameObject.SetActive(true);
            Active_NPC = true;
            NPC = GameObject.FindGameObjectsWithTag("Robot");
        };
    }
}
