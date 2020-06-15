using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{
    private PauseGame pauseGame;

    private bool ActivePlaylistPeace=true;
    private bool OldActivePlaylistPeace=true;

    public float time = 1;
    private float localTime;
    
    private float k;
    public AudioClip[] audioClipsWar;
    private int numberClipWar = 0;
    public AudioClip[] audioClipsPeace;
    private int numberClipPeace = 0;
    private AudioSource audioSource;

    private NPCHelper npcHelper;

    public bool pause = false;
    public bool Level4 = false;
    private Game_logic_4 game_Logic_4;
    private bool inEA = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        npcHelper = GameObject.Find("NPC").GetComponent<NPCHelper>();
        if (Level4)
            game_Logic_4 = GameObject.Find("Robot Player").transform.GetChild(0).GetComponent<Game_logic_4>();
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcHelper.countNPConScene==0)
            ActivePlaylistPeace = true;
        else
            ActivePlaylistPeace = false;
        if (pauseGame.pause)
        {
            ActivePlaylistPeace = true;
        }
        if (!pause)
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
                    StopCoroutine("audioVolume");
                    nextPeace();
                }
                else
                {
                    StopCoroutine("audioVolume");
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
        if (Level4)
        {
            if (inEA!= game_Logic_4.InEasterEgg)
                if (game_Logic_4.InEasterEgg == true)
                {
                    audioSource.Stop();
                    pause = true;
                }
                else
                {
                    audioSource.Play();
                    pause = false;
                }
            inEA = game_Logic_4.InEasterEgg;
        }
        OldActivePlaylistPeace = ActivePlaylistPeace;
    }
    private void nextPeace()
    {
        numberClipPeace = (++numberClipPeace) % audioClipsPeace.Length;
        audioSource.clip = audioClipsPeace[numberClipPeace];
        audioSource.Play();
        StartCoroutine(audioVolume(audioClipsPeace[numberClipPeace].length));
    }
    private void nextWar()
    {
        numberClipWar = (++numberClipWar) % audioClipsWar.Length;
        audioSource.clip = audioClipsWar[numberClipWar];
        audioSource.Play();
        StartCoroutine(audioVolume(audioClipsWar[numberClipWar].length));
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
