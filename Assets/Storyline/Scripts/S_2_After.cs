using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_2_After : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public GameObject[] Friends;
    public GameObject[] texts;
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
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        texts[0].SetActive(false);
        Friends[2].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[1].SetActive(true);
        Backgrounds[1].SetActive(true);
    }
    private void Click2()
    {
        texts[1].SetActive(false);
        Backgrounds[1].SetActive(false);
        texts[2].SetActive(true);
        Friends[1].SetActive(true);
        Backgrounds[0].SetActive(true);
    }
    private void Click3()
    {
        texts[2].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[3].SetActive(true);
        Backgrounds[1].SetActive(true);
    }
    private void Click4()
    {
        texts[3].SetActive(false);
        Backgrounds[1].SetActive(false);
        texts[4].SetActive(true);
        Backgrounds[0].SetActive(true);
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
        Backgrounds[1].SetActive(false);
        texts[6].SetActive(true);
        Friends[2].SetActive(true);
        Backgrounds[0].SetActive(true);
    }
    private void Click7()
    {
        texts[6].SetActive(false);
        Friends[2].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[7].SetActive(true);
        Backgrounds[1].SetActive(true);
    }
    private void Click8()
    {
        texts[7].SetActive(false);
        Backgrounds[1].SetActive(false);
        texts[8].SetActive(true);
        Friends[1].SetActive(true);
        Backgrounds[0].SetActive(true);
    }
    private void Click9()
    {
        Backgrounds[3].SetActive(true);
        Backgrounds[2].SetActive(false);
        Backgrounds[0].SetActive(false);
        button.SetActive(false);
    }
    public void Yes()
    {
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Improvement_Menu");
    }
    public void No()
    {
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(NextLevel);
    }
}
