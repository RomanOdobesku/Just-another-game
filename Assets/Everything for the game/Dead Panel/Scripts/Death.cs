using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private GameObject RobotPlayer;
    bool find=false;
    private GameObject[] robots;
    private Camera camera;
    private bool ItsFightScene = false;

    public GameObject MainText;
    public GameObject SecText;

    public bool ActivePanel = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        camera = null;
        camera = Camera.main;
        if (SceneManager.GetActiveScene().name == "Fight")
            ItsFightScene = true;
        RobotPlayer = GameObject.FindGameObjectWithTag("Robot Player");
    }
    private void Update()
    {
        if (ItsFightScene && !ActivePanel)
        {
            if (GameObject.Find("NPC").GetComponent<NPCHelper>().countNPConScene == 0)
            {
                
                ActiveDeathPanel();
                
            }    
        }
    }

    public void ActiveDeathPanel()
    {
        GameObject.Find("Pause Panel").GetComponent<PauseGame>().OpenPauseMenu();
        Destroy(GameObject.Find("NPC"));
        if (RobotPlayer != null)
        {
            camera.transform.SetParent(null);
        }
        RobotPlayer.SetActive(false);
        ActivePanel = true;
        if (ItsFightScene)
        {
            
            if (GameObject.Find("NPC").GetComponent<NPCHelper>().countNPConScene == 0)
            {
                MainText.GetComponent<Text>().text = "Победа!";
                SecText.GetComponent<Text>().text = "Отряд Спасения уничтожен!";
            }
            else
            {
                MainText.GetComponent<Text>().text = "Поражение!";
                SecText.GetComponent<Text>().text = "Вы были уничтожены!";
            }
            SecText.SetActive(true);
        }
        else
        {
            Debug.Log(RobotPlayer.ToString());
            if (GameObject.Find("NPC").GetComponent<NPCHelper>().countNPCAlies==4 || GameObject.Find("NPC").GetComponent<NPCHelper>().countNPCAlies == 0)
            {
                SecText.GetComponent<Text>().text = "Вы были уничтожены!";
            }
            else
            {
                SecText.GetComponent<Text>().text = "Ваш союзник был уничтожен!";
            }
        }
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(0);
    }
    public void Again()
    {
        Time.timeScale = 1;
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
