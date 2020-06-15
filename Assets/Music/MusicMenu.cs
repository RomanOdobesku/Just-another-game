using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int numberClip = 0;
    private AudioSource audioSource;

    private bool GlobalPause=false;
    public bool MainMenu=true;
    private PauseGame pauseGame;
    private bool oldPause;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!MainMenu)
        {
            pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
            oldPause = !pauseGame.pause;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainMenu)
        {
            if (oldPause != pauseGame.pause)
            {
                if (pauseGame.pause)
                {
                    GlobalPause = true;
                    audioSource.Pause();
                }
                else
                {
                    GlobalPause = false;
                    audioSource.Play();
                }
            }
            oldPause = pauseGame.pause;
        }
        
        if (!GlobalPause)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                numberClip = (++numberClip) % audioClips.Length;
                audioSource.clip = audioClips[numberClip];
                audioSource.Play();
            }
            if (!audioSource.isPlaying)
            {
                numberClip = (++numberClip) % audioClips.Length;
                audioSource.clip = audioClips[numberClip];
                audioSource.Play();
            }
        }
    }
}
