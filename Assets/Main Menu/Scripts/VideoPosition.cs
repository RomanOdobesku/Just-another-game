using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.transform.localScale.x / gameObject.transform.localScale.y);
       
        float w = Screen.width;
        float h = Screen.height;
        Debug.Log(w / h);
        gameObject.transform.localScale = new Vector2(w / h * gameObject.transform.localScale.y, gameObject.transform.localScale.y);
        
    }

}
