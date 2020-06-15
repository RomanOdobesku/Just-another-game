using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public float time = 1;
    private float localTime;
    private int numberClip=0;
    private float k;
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        k= PlayerPrefs.GetFloat("Volume", 1);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            numberClip = (++numberClip) % audioClips.Length;
            audioSource.clip = audioClips[numberClip];
            audioSource.Play();
            StartCoroutine(audioVolume(audioClips[numberClip].length));
        }
    }
    IEnumerator audioVolume(float timeaudio)
    {
        yield return new WaitForSeconds(timeaudio - time);
        localTime = time;
        while (localTime > 0)
        {
            localTime -= Time.deltaTime;
            audioSource.volume= (k* localTime)/time;
            yield return null;
        }
        localTime = time;
        while (localTime > 0)
        {
            localTime -= Time.deltaTime;
            audioSource.volume = (k* (time - localTime)) / time;
            yield return null;
        }
    }
}
