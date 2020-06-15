using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_1_Before : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public GameObject[] texts;
    public GameObject buttonNext;

    private bool goNextGame;

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
            case 13:
                Click13();
                break;
            case 14:
                Click14();
                break;
            case 15:
                Click15();
                break;
            case 16:
                Click16();
                break;
            case 17:
                Click17();
                break;
            case 18:
                Click18();
                break;
            case 19:
                Click19();
                break;
            case 20:
                Click20();
                break;
            case 21:
                Click21();
                break;
            case 22:
                Click22();
                break;
            case 23:
                Click23();
                break;
            case 24:
                Click24();
                break;
            case 25:
                Click25();
                break;
            case 26:
                Click26();
                break;
            case 27:
                Click27();
                break;
            case 28:
                Click28();
                break;
            case 29:
                Click29();
                break;
            case 30:
                Click30();
                break;
            case 31:
                Click31();
                break;
            case 32:
                Click32();
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
    }
    private void Click2()
    {
        Backgrounds[2].SetActive(true);
        Backgrounds[1].SetActive(false);
    }
    private void Click3()
    {
        Backgrounds[3].SetActive(true);
        Backgrounds[2].SetActive(false);
    }
    private void Click4()
    {
        Backgrounds[4].SetActive(true);
        Backgrounds[3].SetActive(false);
    }
    private void Click5()
    {
        Backgrounds[5].SetActive(true);
        Backgrounds[4].SetActive(false);
    }
    private void Click6()
    {
        Backgrounds[6].SetActive(true);
        Backgrounds[5].SetActive(false);
    }
    private void Click7()
    {
        Backgrounds[7].SetActive(true);
        Backgrounds[6].SetActive(false);
    }
    private void Click8()
    {
        Backgrounds[8].SetActive(true);
        Backgrounds[7].SetActive(false);
    }
    private void Click9()
    {
        Backgrounds[9].SetActive(true);
        Backgrounds[8].SetActive(false);
    }
    private void Click10()
    {
        Backgrounds[10].SetActive(true);
        Backgrounds[9].SetActive(false);
    }
    private void Click11()
    {
        Backgrounds[11].SetActive(true);
        texts[0].SetActive(false);
        texts[1].SetActive(true);
    }
    private void Click12()
    {
        Backgrounds[11].SetActive(false);
        Backgrounds[12].SetActive(true);
        texts[1].SetActive(false);
        texts[2].SetActive(true);
    }
    private void Click13()
    {
        Backgrounds[12].SetActive(false);
        Backgrounds[11].SetActive(true);
        texts[2].SetActive(false);
        texts[3].SetActive(true);
    }
    private void Click14()
    {
        Backgrounds[11].SetActive(false);
        Backgrounds[12].SetActive(true);
        texts[3].SetActive(false);
        texts[4].SetActive(true);
    }
    private void Click15()
    {
        Backgrounds[12].SetActive(false);
        Backgrounds[11].SetActive(true);
        texts[4].SetActive(false);
        texts[5].SetActive(true);
    }
    private void Click16()
    {
        Backgrounds[11].SetActive(false);
        Backgrounds[12].SetActive(true);
        texts[5].SetActive(false);
        texts[6].SetActive(true);
    }
    private void Click17()
    {
        Backgrounds[12].SetActive(false);
        Backgrounds[11].SetActive(true);
        texts[6].SetActive(false);
        texts[7].SetActive(true);
    }
    private void Click18()
    {
        Backgrounds[11].SetActive(false);
        Backgrounds[12].SetActive(true);
        texts[7].SetActive(false);
        texts[8].SetActive(true);
    }
    private void Click19()
    {
        Backgrounds[12].SetActive(false);
        Backgrounds[11].SetActive(true);
        texts[8].SetActive(false);
        texts[9].SetActive(true);
    }
    private void Click20()
    {
        texts[9].SetActive(false);
        texts[10].SetActive(true);
    }
    private void Click21()
    {
        texts[10].SetActive(false);
        texts[11].SetActive(true);
    }
    private void Click22()
    {
        texts[11].SetActive(false);
        texts[12].SetActive(true);
    }
    private void Click23()
    {
        Backgrounds[11].SetActive(false);
        Backgrounds[12].SetActive(true);
        texts[12].SetActive(false);
        texts[13].SetActive(true);
    }
    private void Click24()
    {
        Backgrounds[12].SetActive(false);
        Backgrounds[11].SetActive(true);
        texts[13].SetActive(false);
        texts[14].SetActive(true);
    }
    private void Click25()
    {
       
        texts[14].SetActive(false);
        texts[15].SetActive(true);
    }
    private void Click26()
    {
        Backgrounds[11].SetActive(false);
        Backgrounds[12].SetActive(true);
        texts[15].SetActive(false);
        texts[16].SetActive(true);
    }
    private void Click27()
    {
        Backgrounds[12].SetActive(false);
        Backgrounds[11].SetActive(true);
        texts[16].SetActive(false);
        texts[17].SetActive(true);
    }
    private void Click28()
    {
        Backgrounds[11].SetActive(false);
        texts[0].SetActive(false);
        buttonNext.SetActive(false);
        texts[17].SetActive(false);
        texts[18].SetActive(true);
    }
    public void ClickNewChip()
    {
        goNextGame = false;
        Backgrounds[13].SetActive(true);
        buttonNext.SetActive(true);
    }
    public void ClickOldChip()
    {
        goNextGame = true;
        Backgrounds[14].SetActive(true);
        buttonNext.SetActive(true);
    }
    private void Click29()
    {
        if (goNextGame)
        {
            Backgrounds[15].SetActive(true);
            Backgrounds[16].SetActive(true);
            Backgrounds[14].SetActive(false);
        }
        else
        {
            GameObject LoadingPanel = GameObject.Find("Loading Panel");
            LoadingPanel.SetActive(true);
            int NextLevel = PlayerPrefs.GetInt("NextLevel");
            NextLevel = 0;
            PlayerPrefs.SetInt("NextLevel", NextLevel);
            PlayerPrefs.Save();
            LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(NextLevel);
        }
    }
    private void Click30()
    {
        texts[20].SetActive(true);
        Backgrounds[17].SetActive(true);
        texts[19].SetActive(false);
        Backgrounds[16].SetActive(false);
    }
    private void Click31()
    {
        texts[21].SetActive(true);
        Backgrounds[16].SetActive(true);
        texts[20].SetActive(false);
        Backgrounds[17].SetActive(false);
    }
    private void Click32()
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
