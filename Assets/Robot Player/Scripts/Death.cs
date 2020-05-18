using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject DeathPanel;
    GameObject BigExplosion;
    GameObject RoborPlayer;
    bool find=false;
    GameObject[] robots;
    // Start is called before the first frame update
    void Start()
    {
        RoborPlayer = GameObject.FindGameObjectWithTag("Robot Player");
    }

    // Update is called once per frame
    void Update()
    {
        BigExplosion = GameObject.Find("BigExplosion(Clone)");
        if (BigExplosion!= null && !find)
        {
            find = true;
        }
        if (BigExplosion == null && find && RoborPlayer==null)
        {
            ActiveDeathPanel();
        }
    }
    private void ActiveDeathPanel()
    {
        robots = GameObject.FindGameObjectsWithTag("Robot");
        foreach (GameObject robot in robots)
        {
            Destroy(robot);
        }
        DeathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
