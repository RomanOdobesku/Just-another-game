using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTetrisHelper : MonoBehaviour
{
    public GameObject TetrisCamera;
    private bool PlayNow=true;
    private bool PlayOld=true;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayNow = !TetrisCamera.activeInHierarchy;
        if (PlayOld!= PlayNow)
        {
            if (PlayNow)
                audioSource.mute = false;
            else
                audioSource.mute = true;
        }
        PlayOld = PlayNow;
    }
}
