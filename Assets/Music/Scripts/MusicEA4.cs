using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEA4 : MonoBehaviour
{
    private PauseGame pauseGame;

    public float time = 1;
    private float localTime;

    private float k;
    public AudioClip[] audioClips;
    private int numberClip = 0;
    private AudioSource audioSource;

    public bool pause = true;
    private bool oldPause =false;
    private Game_logic_4 game_Logic_4;
    private bool inEA = true;
    private TV tv;
    
    // Start is called before the first frame update
    void Start()
    {
        tv = GameObject.Find("TV").GetComponent<TV>();
        audioSource = GetComponent<AudioSource>();
        game_Logic_4 = GameObject.Find("Robot Player").transform.GetChild(0).GetComponent<Game_logic_4>();
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tv.VideoActive || !game_Logic_4.InEasterEgg)
            audioSource.mute = true;
        else
            audioSource.mute = false;
        if (!pause)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                StopCoroutine("audioVolume");
                numberClip = (++numberClip) % audioClips.Length;
                audioSource.clip = audioClips[numberClip];
                audioSource.Play();
                StartCoroutine(audioVolume(audioClips[numberClip].length));  
            }
            if (!audioSource.isPlaying)
            {
                numberClip = (++numberClip) % audioClips.Length;
                audioSource.clip = audioClips[numberClip];
                audioSource.Play();
                StartCoroutine(audioVolume(audioClips[numberClip].length));
            }
        }
        oldPause = pause;
        inEA = game_Logic_4.InEasterEgg;
    }
    IEnumerator audioVolume(float timeaudio)
    {
        yield return new WaitForSeconds(timeaudio - time);
        localTime = time;
        while (localTime > 0)
        {
            localTime -= Time.deltaTime;
            audioSource.volume = (k * localTime) / time;
            yield return null;
        }
        localTime = time;
        while (localTime > 0)
        {
            localTime -= Time.deltaTime;
            audioSource.volume = (k * (time - localTime)) / time;
            yield return null;
        }
    }
}
