using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject ExitPanel;
    public GameObject Buttons;
    public GameObject PauseText;
    public GameObject ExitButton;
    public bool IsLevel=false;
    public bool pause = false;
    
    // Start is called before the first frame update
    void Start()
    {
        float height = (Screen.height-60);
        ExitButton.transform.localPosition = new Vector3(ExitButton.transform.localPosition.x, 0 - height*0.25f);
        PauseText.transform.localPosition = new Vector3(PauseText.transform.localPosition.x, height*0.375f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pause)
            {
                if (IsLevel)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                }
                pause = true;
                PausePanel.SetActive(true);
            }
            else
            {
                ClosePauseMenu();
            }
        }
    }
   
    public void Exit()
    {
        Time.timeScale = 1;
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(0);
    }
    private void ClosePauseMenu()
    {
        pause = false;
        if (ExitPanel.activeInHierarchy == true)
        {
            ExitPanel.SetActive(false);
            Buttons.SetActive(true);
        }

        PausePanel.SetActive(false);
        if (IsLevel)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
    public void Continue()
    {
        ClosePauseMenu();
    }

}
