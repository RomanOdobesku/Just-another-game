using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_1_After : MonoBehaviour
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
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        texts[1].SetActive(true);
        Backgrounds[3].SetActive(true);
        texts[0].SetActive(false);
        Backgrounds[2].SetActive(false);
        Friends[1].SetActive(false);
    }
    private void Click2()
    {
        texts[1].SetActive(false);
        Backgrounds[2].SetActive(true);
        texts[2].SetActive(true);
        Backgrounds[3].SetActive(false);
        Friends[2].SetActive(true);
    }
    private void Click3()
    {
        texts[2].SetActive(false);
        texts[3].SetActive(true);
    }
    private void Click4()
    {
        texts[4].SetActive(true);
        Backgrounds[3].SetActive(true);
        texts[3].SetActive(false);
        Backgrounds[2].SetActive(false);
    }
    private void Click5()
    {
        texts[4].SetActive(false);
        Backgrounds[2].SetActive(true);
        texts[5].SetActive(true);
        Backgrounds[3].SetActive(false);
        
    }
    private void Click6()
    {
        texts[5].SetActive(false);
        texts[6].SetActive(true);
    }
    private void Click7()
    {
        Friends[2].SetActive(false);
        Friends[1].SetActive(true);
        texts[6].SetActive(false);
        Backgrounds[1].SetActive(true);
        texts[7].SetActive(true);
        Backgrounds[0].SetActive(false);
    }
    private void Click8()
    {
        texts[7].SetActive(false);
        texts[8].SetActive(true);
    }
    private void Click9()
    {
        texts[8].SetActive(false);
        texts[9].SetActive(true);
    }
    private void Click10()
    {
        texts[9].SetActive(false);
        texts[10].SetActive(true);
    }
    private void Click11()
    {
        texts[10].SetActive(false);
        texts[11].SetActive(true);
    }
    private void Click12()
    {
        texts[11].SetActive(false);
        texts[12].SetActive(true);
    }
    private void Click13()
    {
        texts[12].SetActive(false);
        texts[13].SetActive(true);
    }
    private void Click14()
    {
        texts[13].SetActive(false);
        texts[14].SetActive(true);
        Backgrounds[2].SetActive(false);
        Backgrounds[3].SetActive(true);
    }
    private void Click15()
    {
        texts[14].SetActive(false);
        texts[15].SetActive(true);
        Backgrounds[3].SetActive(false);
        Backgrounds[2].SetActive(true);
    }
    private void Click16()
    {
        texts[15].SetActive(false);
        Friends[1].SetActive(false);
        texts[16].SetActive(true);
        Backgrounds[3].SetActive(true);
        Backgrounds[2].SetActive(false);
    }
    private void Click17()
    {
        texts[16].SetActive(false);
        Friends[3].SetActive(true);
        texts[17].SetActive(true);
        Backgrounds[2].SetActive(true);
        Backgrounds[3].SetActive(false);
    }
    private void Click18()
    {
        texts[17].SetActive(false);
        Friends[3].SetActive(false);
        texts[18].SetActive(true);
        Backgrounds[3].SetActive(true);
        Backgrounds[2].SetActive(false);
    }
    private void Click19()
    {
        texts[18].SetActive(false);
        Friends[2].SetActive(true);
        texts[19].SetActive(true);
        Backgrounds[2].SetActive(true);
        Backgrounds[3].SetActive(false);
    }
    private void Click20()
    {
        texts[19].SetActive(false);
        Friends[2].SetActive(false);
        texts[20].SetActive(true);
        Backgrounds[3].SetActive(true);
        Backgrounds[2].SetActive(false);
    }
    private void Click21()
    {
        texts[20].SetActive(false);
        Friends[1].SetActive(true);
        texts[21].SetActive(true);
        Backgrounds[2].SetActive(true);
        Backgrounds[3].SetActive(false);
    }
    private void Click22()
    {
        texts[21].SetActive(false);
        texts[22].SetActive(true);
    }
    private void Click23()
    {
        texts[22].SetActive(false);
        texts[23].SetActive(true);
    }
    private void Click24()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(1);
    }
}
