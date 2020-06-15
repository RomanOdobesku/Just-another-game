using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Audio : MonoBehaviour
{
    private float Volume;
    // Start is called before the first frame update
    void Start()
    {
        Volume=PlayerPrefs.GetFloat("Volume", 1);
        gameObject.GetComponent<AudioSource>().volume = Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
