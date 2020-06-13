using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_3_After : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public GameObject button;

    private int numberClick=1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {}

    public void Click()
    {
        Debug.Log(numberClick.ToString());
        switch (numberClick)
        {
            case 1:
                Click1();
                break;
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        Backgrounds[2].SetActive(true);
        Backgrounds[1].SetActive(false);
        Backgrounds[0].SetActive(false);
        button.SetActive(false);
    }
    public void Yes()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(1);
    }
    public void No()
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
