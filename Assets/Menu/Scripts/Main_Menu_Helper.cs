using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Helper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start_campany()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Start_fight()
    {
        SceneManager.LoadScene("Improvement_Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
