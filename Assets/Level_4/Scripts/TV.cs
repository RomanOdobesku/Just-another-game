using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public GameObject Loading;
    public GameObject[] Videos;

    void Start()
    {
        Loading.SetActive(true);
    }
    
    public void StartVideoRoma()
    {
        EndAllVideo();
        Videos[0].SetActive(true);
    }
    public void StartVideoEgor()
    {
        EndAllVideo();
        Videos[1].SetActive(true);
    }
    public void StartVideoAny()
    {
        EndAllVideo();
        Videos[2].SetActive(true);
    }
    public void StartVideoSasha()
    {
        EndAllVideo();
        Videos[3].SetActive(true);
    }
    private void EndAllVideo()
    {
        foreach (var item in Videos)
        {
            item.SetActive(false);
        }
        Loading.SetActive(false);
    }
}

