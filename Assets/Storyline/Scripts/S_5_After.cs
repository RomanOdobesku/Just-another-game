using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_5_After : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public GameObject[] Friends;
    public GameObject[] texts;
    public Button button;

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
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        texts[0].SetActive(false);
        Friends[1].SetActive(false);
        texts[1].SetActive(true);
        Friends[2].SetActive(true);
    }
    private void Click2()
    {
        texts[1].SetActive(false);
        Friends[2].SetActive(false);
        texts[2].SetActive(true);
        Friends[0].SetActive(true);
    }
    private void Click3()
    {
        Backgrounds[1].SetActive(true);
        Backgrounds[2].SetActive(false);
        Backgrounds[0].SetActive(false);
        button.GetComponentInChildren<Text>().text = "Конец";
    }
    private void Click4()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
