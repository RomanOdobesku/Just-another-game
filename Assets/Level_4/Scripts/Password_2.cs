using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Password_2 : MonoBehaviour
{
    public int password;
    public InputField _password;
    public GameObject ErrorPassword;

    public GameObject DisplayIm;
    public GameObject NPC;
    public GameObject PanelPassword;

    public GameObject MyDoor;
    public Text OpenDoor;
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
                HealthBar = GameObject.FindGameObjectsWithTag("HealthBar");
                foreach (GameObject item in HealthBar)
                {
                    item.SetActive(false);
                }
                PanelPassword.SetActive(true);
                DisplayIm.SetActive(true);
                NPC.SetActive(false);
                OpenDoor.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
            OpenDoor.gameObject.SetActive(false);
            inTrigger = false;
        };
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Robot Player") && !IsOpen)
        {
            OpenDoor.gameObject.SetActive(true);
            inTrigger = true;
        };
    }
    public void ExitPassword()
    {
        PanelPassword.SetActive(false);
        NPC.SetActive(true);
        foreach (GameObject item in HealthBar)
        {
            item.SetActive(true);
        }
        DisplayIm.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
