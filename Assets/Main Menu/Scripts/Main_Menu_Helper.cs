using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Helper : MonoBehaviour
{
    public GameObject buttonСontinue;

    int NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("NextLevel"))
        {
            NextLevel = PlayerPrefs.GetInt("NextLevel");
        }
        else
        {
            PlayerPrefs.SetInt("NextLevel", 0);
            NextLevel = 0;
        }
        if (NextLevel < 2)
        {
            buttonСontinue.SetActive(false);
        }
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Сontinue_campany()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(NextLevel);
    }
    public void New_campany()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        PlayerPrefs.SetInt("NextLevel", 2);
        PlayerPrefs.SetInt("Speed", 0);
        PlayerPrefs.SetInt("Health", 0);
        PlayerPrefs.SetInt("Damage", 0);
        PlayerPrefs.SetInt("MaterialPlayer", 0);
        PlayerPrefs.SetInt("CountBonus", 0);
        NextLevel = PlayerPrefs.GetInt("NextLevel");
        PlayerPrefs.Save();
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(NextLevel);
    }
    public void Start_fight()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(16);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
