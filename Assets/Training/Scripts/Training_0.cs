﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_0 : MonoBehaviour
{
    private int step = 0;
    public GameObject[] texts;
    public GameObject button;
    private PauseGame pauseGame;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
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
                button.SetActive(false);
                if (Input.GetKeyDown(KeyCode.P))
                {
                    step++;
                }
                break;
            case 2:
                texts[1].SetActive(false);
                texts[2].SetActive(true);
                if (pauseGame.pause == false)
                {
                    step++;
                }
                break;
            case 3:
                GameObject LoadingPanel = GameObject.Find("Loading Panel");
                LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
                LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(18);
                step++;
                break;
            
            default:
                break;
        }
    }
}