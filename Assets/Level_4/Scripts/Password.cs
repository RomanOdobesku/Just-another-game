using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
    public int password;
    public InputField _password;
    public GameObject ErrorPassword;

    public GameObject Player;
    public GameObject NPC;
    public GameObject PasswordCamera;
    public GameObject PanelPassword;
    public GameObject MainPanel;
    public GameObject kill_Ch;

    public GameObject MyDoor;
    public Text OpenDoor;
    public GameObject killAllNPC;
    Door door;
    bool inTrigger;
    bool IsOpen = false;
    GameObject[] HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        door = MyDoor.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (kill_Ch.activeInHierarchy == true)
                {
                    HealthBar = GameObject.FindGameObjectsWithTag("HealthBar");
                    foreach (GameObject item in HealthBar)
                    {
                        item.SetActive(false);
                    }
                    PanelPassword.SetActive(true);
                    Player.SetActive(false);
                    NPC.SetActive(false);
                    MainPanel.SetActive(false);
                    PasswordCamera.SetActive(true);
                    OpenDoor.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
    public void CkechPassword()
    {
        if (password.ToString() != _password.text)
        {
            ErrorPassword.SetActive(true);
            _password.text = "";
            StartCoroutine(TimerError());
            OpenDoor.gameObject.SetActive(false);
        }
        else
        {
            ExitPassword();
            door.go = 1;
            IsOpen = true;
        }
    }
    IEnumerator TimerError()
    {
        ErrorPassword.SetActive(true);
        yield return new WaitForSeconds(2);
        ErrorPassword.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (other.CompareTag("Robot Player"))
        {
            if (OpenDoor.gameObject.activeInHierarchy == true)
                OpenDoor.gameObject.SetActive(false);
            if (killAllNPC.activeInHierarchy == true)
                killAllNPC.SetActive(false);
            inTrigger = false;
        };
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Robot Player") && !IsOpen)
        {
            inTrigger = true;
            if (kill_Ch.activeInHierarchy==true)
            {
                OpenDoor.gameObject.SetActive(true);
            }
            else
            {
                killAllNPC.SetActive(true);
            }
        };
    }
    public void ExitPassword()
    {
        MainPanel.SetActive(true);
        PanelPassword.SetActive(false);
        Player.SetActive(true);
        NPC.SetActive(true);
        foreach (GameObject item in HealthBar)
        {
            item.SetActive(true);
        }
        PasswordCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
