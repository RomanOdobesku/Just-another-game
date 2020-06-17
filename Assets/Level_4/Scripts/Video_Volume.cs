using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Volume : MonoBehaviour
{
    private float Volume;

    private PauseGame pauseGame;
    private bool PlayNow = true;
    private bool PlayOld = true;
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Volume = PlayerPrefs.GetFloat("Volume", 1);
        videoPlayer= gameObject.GetComponent<VideoPlayer>();
        Debug.Log("volume" + PlayerPrefs.GetFloat("Volume", 1));
        videoPlayer.SetDirectAudioVolume(0, Volume);
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
        PlayOld = PlayNow = !pauseGame.pause;
    }

    // Update is called once per frame
    void Update()
    {
        PlayNow = !pauseGame.pause;
        if (PlayNow != PlayOld)
        {
            if (PlayNow)
                videoPlayer.Play();
            else
                videoPlayer.Pause();
        }
        PlayOld = PlayNow;
    }
}
