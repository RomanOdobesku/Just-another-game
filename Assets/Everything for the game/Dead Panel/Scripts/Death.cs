using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    GameObject DeathPanel;
    GameObject RoborPlayer;
    bool find=false;
    GameObject[] robots;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        DeathPanel = GameObject.Find("Death Panel");
        RoborPlayer = GameObject.FindGameObjectWithTag("Robot Player");
    }

    // Update is called once per frame
    void Update()
    {
        //BigExplosion = GameObject.Find("BigExplosion(Clone)");
        //if (BigExplosion!= null && !find)
        //{
        //    find = true;
        //}
        //if (BigExplosion == null && find && RoborPlayer==null)
        //{
        //    ActiveDeathPanel();
        //}
    }
    public void ActiveDeathPanel()
    {
        Destroy(GameObject.Find("NPC"));
        if (RoborPlayer != null)
        {
            camera.transform.SetParent(null);
        }
        //Destroy(RoborPlayer);
        //robots = GameObject.FindGameObjectsWithTag("HealthBar");
        //foreach (GameObject item in robots)
        //{
        //    Destroy(item);
        //}
        DeathPanel.transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
