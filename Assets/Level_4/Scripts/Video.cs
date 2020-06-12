using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    VideoPlayer _videoPlayer;
    public GameObject Loading;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.Prepare();

        _videoPlayer.loopPointReached += _videoPlayer_loopPointReached;

        _videoPlayer.Play();
    }

    private void _videoPlayer_loopPointReached(VideoPlayer source)
    {
        Loading.SetActive(true);
        gameObject.SetActive(false);
    }
}