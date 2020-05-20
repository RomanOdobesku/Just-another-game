using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*
     * 
     *      -1  закрыть дверь
     *       1  открыть дверь
     * 
     */
    public GameObject left_door;
    Vector3 beg_left;
    public GameObject end_left;
    public GameObject right_door;
    Vector3 beg_right;
    public GameObject end_right;
    public int go = -1;
    public float speed = 120;
    // Start is called before the first frame update
    void Start()
    {
        beg_left = left_door.transform.position;
        beg_right = right_door.transform.position;
    }
    
    void Update()
    {
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
    }
}
