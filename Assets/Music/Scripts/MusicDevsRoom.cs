using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicDevsRoom : MonoBehaviour
{

    private PauseGame pauseGame;

    public float time = 1;
    private float localTime;

    private float k;
    public AudioClip[] audioClips;
    private int numberClip = 0;
    private AudioSource audioSource;
    
    private TV tv;
    private bool PlayNow=false;
    public bool PlayOld=false;
    // Start is called before the first frame update
    void Start()
    {
        k = PlayerPrefs.GetFloat("Volume");
        tv = GameObject.Find("TV").GetComponent<TV>();
        audioSource = GetComponent<AudioSource>();
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tv.VideoActive && !pauseGame.pause)
        {
            PlayNow = true;
        }
        else
        {
            PlayNow = false;
        }
        if (PlayNow != PlayOld)
        {
            if (PlayNow)
            {
                audioSource.Play();
                Debug.Log("Play()");
            }
            else
            {
                Debug.Log("PAUSE()");
                audioSource.Pause();
            }
                
        }
        if (PlayNow)
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
        PlayOld = PlayNow;
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
