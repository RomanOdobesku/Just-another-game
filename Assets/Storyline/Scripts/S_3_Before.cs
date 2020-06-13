using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_3_Before : MonoBehaviour
{
    public GameObject[] texts;
    int numberClick = 1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Click()
    {
        switch (numberClick)
        {
            case 1:
                Click1();
                break;
            case 2:
                Click2();
                break;
            case 3:
                Click3();
                break;
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        texts[0].SetActive(false);
        texts[1].SetActive(true);
    }
    private void Click2()
    {
        texts[1].SetActive(false);
        texts[2].SetActive(true);
    }
    private void Click3()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(NextLevel);
    }
}
