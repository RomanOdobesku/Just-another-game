using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_5_Before : MonoBehaviour
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
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {

        texts[0].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[1].SetActive(true);
        Backgrounds[1].SetActive(true);

    }
    private void Click2()
    {
        texts[1].SetActive(false);
        Backgrounds[1].SetActive(false);
        texts[2].SetActive(true);
        Backgrounds[0].SetActive(true);
    }
    private void Click3()
    {
        Friends[0].SetActive(false);
        texts[2].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[3].SetActive(true);
        Backgrounds[1].SetActive(true);
    }
    private void Click4()
    {
        texts[3].SetActive(false);
        Backgrounds[1].SetActive(false);
        Friends[1].SetActive(true);
        texts[4].SetActive(true);
        Backgrounds[0].SetActive(true);
        
    }
    private void Click5()
    {
        texts[4].SetActive(false);
        Friends[1].SetActive(false);
        Friends[0].SetActive(true);
        texts[5].SetActive(true);
    }
    private void Click6()
    {
        texts[5].SetActive(false);
        Friends[0].SetActive(false);
        Friends[2].SetActive(true);
        texts[6].SetActive(true);
    }
    private void Click7()
    {
        Friends[2].SetActive(false);
        texts[6].SetActive(false);
        Backgrounds[0].SetActive(false);
        texts[7].SetActive(true);
        Backgrounds[1].SetActive(true);
    }
    private void Click8()
    {
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(NextLevel);
    }
}
