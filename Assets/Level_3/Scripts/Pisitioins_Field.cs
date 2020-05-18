using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisitioins_Field : MonoBehaviour
{
    public GameObject begin_position;
    public GameObject end_position;
    
    public float Speed = 1f;
    public bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            transform.position= Vector3.MoveTowards(transform.position, end_position.transform.position, Time.deltaTime * Speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, begin_position.transform.position, Time.deltaTime * Speed);
        }
        if (transform.position.y >= end_position.transform.position.y-0.1f)
            up = false;
        if (transform.position.y <= begin_position.transform.position.y + 0.1f)
            up = true;
    }
}
