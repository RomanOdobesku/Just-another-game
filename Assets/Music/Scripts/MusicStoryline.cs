using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStoryline : MonoBehaviour
{
    private AudioSource audioSource;
    
    private PauseGame pauseGame;
    private bool oldPause;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
        oldPause = !pauseGame.pause;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldPause != pauseGame.pause)
        {
            if (pauseGame.pause)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }
        oldPause = pauseGame.pause;
    }
}
