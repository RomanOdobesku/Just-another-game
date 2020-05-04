using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
    public float Height = 5f;
    public float Speed = 1f;
    public float Min_speed = 0.5f;
    Vector3 begin_pos;
    Vector3 end_pos;
    Vector3 go_pos;
    float speed_now;
    // Start is called before the first frame update
    void Start()
    {
        begin_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        end_pos = new Vector3(transform.position.x, transform.position.y+Height, transform.position.z);
        go_pos = end_pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= end_pos.y)
        {
            go_pos = begin_pos;
        }
        if (transform.position.y <= begin_pos.y)
        {
            go_pos = end_pos;
        }
        speed_now =  Speed*Mathf.Cos((Mathf.PI*2* Mathf.Abs(begin_pos.y - transform.position.y)/Height) + Mathf.PI) + Min_speed+Speed;
        transform.position = Vector3.MoveTowards(transform.position, go_pos, Time.deltaTime*speed_now);
    }  
}
