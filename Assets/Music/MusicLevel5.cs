using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel5 : MonoBehaviour
{
    private bool ActivePlaylistPeace = true;
    private bool OldActivePlaylistPeace = true;

    public AudioClip audioClipsMem;
    public AudioClip[] audioClipsWar;
    private int numberClipWar = 0;
    public AudioClip[] audioClipsPeace;
    private int numberClipPeace = 0;
    private AudioSource audioSource;

    private NPCHelper npcHelper;

    private bool GlobalPause = false;
    private PauseGame pauseGame;
    private bool oldPause;

    public bool EasterEgg = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("MusicBoss") == 1)
        {
            EasterEgg = true;
            audioSource.clip = audioClipsMem;
            audioSource.loop = true;
            audioSource.Play();
        }
        npcHelper = GameObject.Find("NPC").GetComponent<NPCHelper>();
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
    }

    // Update is called once per frame
    void Update()
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
        oldPause = GlobalPause;
        if (!EasterEgg)
        {
            if (npcHelper.countNPConScene == 0)
                ActivePlaylistPeace = true;
            else
                ActivePlaylistPeace = false;
            if (!GlobalPause)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    if (ActivePlaylistPeace)
                    {
                        StopCoroutine("audioVolume");
                        nextPeace();
                    }
                    else
                    {
                        StopCoroutine("audioVolume");
                        nextWar();
                    }
                }
                if (OldActivePlaylistPeace != ActivePlaylistPeace)
                {
                    if (ActivePlaylistPeace)
                    {
                        nextPeace();
                    }
                    else
                    {
                        nextWar();
                    }
                }
                else
                {
                    if (!audioSource.isPlaying)
                    {
                        if (ActivePlaylistPeace)
                        {
                            nextPeace();
                        }
                        else
                        {
                            nextWar();
                        }
                    }
                }
            }
            OldActivePlaylistPeace = ActivePlaylistPeace;
        }
    }
    private void nextPeace()
    {
        numberClipPeace = (++numberClipPeace) % audioClipsPeace.Length;
        audioSource.clip = audioClipsPeace[numberClipPeace];
        audioSource.Play();
    }
    private void nextWar()
    {
        numberClipWar = (++numberClipWar) % audioClipsWar.Length;
        audioSource.clip = audioClipsWar[numberClipWar];
        audioSource.Play();
    }
}
