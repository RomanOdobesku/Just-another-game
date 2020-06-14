using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_3 : MonoBehaviour
{
    private int step = 0;
    public GameObject[] texts;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Click()
    {
        step++;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(step);
        switch (step)
        {
            case 1:
                texts[0].SetActive(false);
                texts[1].SetActive(true);
                break;
            case 2:
                texts[1].SetActive(false);
                texts[2].SetActive(true);
                break;
            case 3:
                texts[2].SetActive(false);
                texts[3].SetActive(true);
                break;
            case 4:
                GameObject LoadingPanel = GameObject.Find("Loading Panel");
                LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
                LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(0);
                step++;
                break;
        }
    }
}
