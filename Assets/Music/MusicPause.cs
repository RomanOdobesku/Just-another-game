using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPause : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int numberClip = 0;
    private AudioSource audioSource;

    private bool GlobalPause;
    private PauseGame pauseGame;
    private bool oldPause;
    private float timeaudio;
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
        if (oldPause!= pauseGame.pause)
        {
            if (pauseGame.pause)
            {
                GlobalPause = false;
                audioSource.Play();
            }
            else
            {
                GlobalPause = true;
                audioSource.Pause();
            }
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
        oldPause = pauseGame.pause;
    }
}
