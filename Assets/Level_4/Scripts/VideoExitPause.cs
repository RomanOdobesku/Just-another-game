using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoExitPause : MonoBehaviour
{

    private Game_logic_4 game_Logic_4;
    private bool PlayNow = true;
    private bool PlayOld = true;
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        game_Logic_4 = GameObject.Find("Robot Player").transform.GetChild(0).GetComponent<Game_logic_4>();
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayNow = game_Logic_4.InEasterEgg;
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
