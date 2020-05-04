using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales : MonoBehaviour
{
    public float Min_scale = 1;
    public float Max_scale = 1.5f;
    public float Speed=1;
    public float Min_speed = 0.2f;
    Vector3 begin_scale;
    Vector3 end_scale;
    Vector3 go_scale;
    float speed_now;
    // Start is called before the first frame update
    void Start()
    {
        begin_scale = new Vector3(transform.localScale.x * Min_scale, transform.localScale.y * Min_scale, transform.localScale.z * Min_scale);
        end_scale=new Vector3(transform.localScale.x * Max_scale, transform.localScale.y * Max_scale, transform.localScale.z * Max_scale);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= begin_scale.x)
        {
            go_scale = end_scale;
        }
        if (transform.localScale.x >= end_scale.x)
        {
            go_scale = begin_scale;
        }
        speed_now = Speed * Mathf.Cos((Mathf.PI * 2 * Mathf.Abs(end_scale.y - transform.localScale.y-100) / (end_scale.x-begin_scale.x)) + Mathf.PI) +  Speed+Min_speed;
        transform.localScale = Vector3.MoveTowards(transform.localScale,go_scale,Time.deltaTime*100*Speed);
    }
}
