using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{
    private bool ActivePlaylistPeace=true;
    private bool OldActivePlaylistPeace=true;
    
    public AudioClip[] audioClipsWar;
    private int numberClipWar = 0;
    public AudioClip[] audioClipsPeace;
    private int numberClipPeace = 0;
    private AudioSource audioSource;

    private NPCHelper npcHelper;

    private bool GlobalPause = false;
    private PauseGame pauseGame;
    private bool oldPause;

    public bool Level4 = false;
    private Game_logic_4 game_Logic_4;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        npcHelper = GameObject.Find("NPC").GetComponent<NPCHelper>();
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
        if (Level4)
        {
            game_Logic_4 = GameObject.Find("Robot Player").transform.GetChild(0).GetComponent<Game_logic_4>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(npcHelper.countNPConScene);
        if (npcHelper.countNPConScene==0)
            ActivePlaylistPeace = true;
        else
            ActivePlaylistPeace = false;
        if (Level4)
        {
            if(oldPause != pauseGame.pause || oldPause != game_Logic_4.InEasterEgg)
        {
                if (pauseGame.pause || game_Logic_4.InEasterEgg)
                {
                    GlobalPause = true;
                    audioSource.Pause();
                }
                if (!pauseGame.pause && !game_Logic_4.InEasterEgg)
                {
                    GlobalPause = false;
                    audioSource.Play();
                }
            }
        }
        else
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
        }
        oldPause = GlobalPause;
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
