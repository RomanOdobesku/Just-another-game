using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_4_Before : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public GameObject[] Friends;
    public GameObject[] texts;

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
            case 2:
                Click2();
                break;
            case 3:
                Click3();
                break;
            case 4:
                Click4();
                break;
            case 5:
                Click5();
                break;
            case 6:
                Click6();
                break;
            case 7:
                Click7();
                break;
            case 8:
                Click8();
                break;
            case 9:
                Click9();
                break;
            case 10:
                Click10();
                break;
            case 11:
                Click11();
                break;
            case 12:
                Click12();
                break;
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        Backgrounds[1].SetActive(true);
        Backgrounds[0].SetActive(false);
        texts[0].SetActive(false);
        Friends[0].SetActive(false);
        Backgrounds[3].SetActive(false);
        texts[1].SetActive(true);
        Backgrounds[4].SetActive(true);
    }
    private void Click2()
    {
        texts[1].SetActive(false);
        Backgrounds[4].SetActive(false);
        texts[2].SetActive(true);
        Friends[1].SetActive(true);
        Backgrounds[3].SetActive(true);
    }
    private void Click3()
    {
        Backgrounds[2].SetActive(true);
        Backgrounds[1].SetActive(false);
        Friends[1].SetActive(false);
        Friends[2].SetActive(false);
        texts[2].SetActive(false);
        Friends[0].SetActive(true);
        Friends[3].SetActive(true);
        texts[3].SetActive(true);
    }
    private void Click4()
    {
        texts[3].SetActive(false);
        Backgrounds[3].SetActive(false);
        texts[4].SetActive(true);
        Backgrounds[4].SetActive(true);
    }
    private void Click5()
    {
        texts[4].SetActive(false);
        Friends[1].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[5].SetActive(true);
        Backgrounds[1].SetActive(true);
    }
    private void Click6()
    {
        texts[5].SetActive(false);
        Backgrounds[4].SetActive(false);
        texts[6].SetActive(true);
        Backgrounds[3].SetActive(true);
    }
    private void Click7()
    {
        texts[6].SetActive(false);
        Friends[0].SetActive(false);
        Friends[1].SetActive(true);
        texts[7].SetActive(true);
    }
    private void Click8()
    {
        texts[7].SetActive(false);
        Friends[1].SetActive(false);
        Backgrounds[3].SetActive(false);
        texts[8].SetActive(true);
        Backgrounds[4].SetActive(true);
    }
    private void Click9()
    {
        texts[8].SetActive(false);
        Friends[0].SetActive(true);
        Backgrounds[4].SetActive(false);
        texts[9].SetActive(true);
        Backgrounds[3].SetActive(true);
    }
    private void Click10()
    {
        texts[9].SetActive(false);
        Friends[0].SetActive(false);
        Friends[1].SetActive(true);
        texts[10].SetActive(true);
    }
    private void Click11()
    {
        texts[10].SetActive(false);
        Friends[1].SetActive(false);
        Backgrounds[3].SetActive(false);
        texts[11].SetActive(true);
        Backgrounds[4].SetActive(true);
    }
    private void Click12()
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
