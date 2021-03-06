﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg3 : MonoBehaviour
{
    private GameObject Player;
    private GameObject camerabase;
    public Camera camera;

    public GameObject Body;
    public GameObject LeftPlate;
    public GameObject RearPlate;
    public GameObject RightPlate;
    public GameObject eyeLid;

    public GameObject Task_Ch;
    public GameObject EasterEggPanel;
    private GameObject MainPanel;

    public Material[] mat;

    public Text Attention;
    public Text Congratulations;
    public Text Сonvert;

    private GameObject[] health;

    public bool FindEA=false;

    private bool EndLevel = false;

    private PauseGame pauseGame;
    void Start()
    {
        pauseGame = GameObject.Find("Pause Panel").GetComponent<PauseGame>();
        Player = GameObject.Find("Robot Player");
        camerabase = Player.transform.GetChild(1).gameObject;
        MainPanel = GameObject.Find("Main_Panel");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Easter egg"))
        {
            other.gameObject.SetActive(false);
            OpenPanel();
            FindEA = true;
        }
    }
    public void OpenPanel()
    {
        camera.transform.SetParent(null);
        Player.SetActive(false);
        health = GameObject.FindGameObjectsWithTag("HealthBar");
        pauseGame.IsLevel = false;
        foreach (var item in health)
        {
            item.SetActive(false);
        }
        Task_Ch.SetActive(true);
        MainPanel.SetActive(false);
        EasterEggPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void EndLevelMethod()
    {
        EndLevel = true;
        Attention.text = "Внимание: раскаска сохранится до конца игры!";
        Congratulations.text = "Сейчас Вы можете изменить раскраску Трансформато";
        Сonvert.text = "У вас больше не будет шанса изменить свой выбор!";
    }
    public void mat0()
    {
        ClosePanel(0);
    }
    public void mat1()
    {
        Body.GetComponent<MeshRenderer>().material = mat[0];
        LeftPlate.GetComponent<MeshRenderer>().material = mat[0];
        RearPlate.GetComponent<MeshRenderer>().material = mat[0];
        RightPlate.GetComponent<MeshRenderer>().material = mat[0];
        eyeLid.GetComponent<MeshRenderer>().material = mat[0];
        ClosePanel(1);
    }
    public void mat2()
    {
        Body.GetComponent<MeshRenderer>().material = mat[1];
        LeftPlate.GetComponent<MeshRenderer>().material = mat[1];
        RearPlate.GetComponent<MeshRenderer>().material = mat[1];
        RightPlate.GetComponent<MeshRenderer>().material = mat[1];
        eyeLid.GetComponent<MeshRenderer>().material = mat[1];
        ClosePanel(2);
    }
    public void mat3()
    {
        Body.GetComponent<MeshRenderer>().material = mat[2];
        LeftPlate.GetComponent<MeshRenderer>().material = mat[2];
        RearPlate.GetComponent<MeshRenderer>().material = mat[2];
        RightPlate.GetComponent<MeshRenderer>().material = mat[2];
        eyeLid.GetComponent<MeshRenderer>().material = mat[2];
        ClosePanel(3);
    }
    public void mat4()
    {
        Body.GetComponent<MeshRenderer>().material = mat[3];
        LeftPlate.GetComponent<MeshRenderer>().material = mat[3];
        RearPlate.GetComponent<MeshRenderer>().material = mat[3];
        RightPlate.GetComponent<MeshRenderer>().material = mat[3];
        eyeLid.GetComponent<MeshRenderer>().material = mat[3];
        ClosePanel(4);
    }
    private void ClosePanel(int Mat)
    {
        foreach (var item in health)
        {
            item.SetActive(true);
        }
        EasterEggPanel.SetActive(false);
        MainPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        
        Player.SetActive(true);
        camera.transform.SetParent(camerabase.transform);
        if (EndLevel)
        {
            gameObject.GetComponent<Game_logic_3>().goScene4();
            PlayerPrefs.SetInt("MaterialPlayer", Mat);
            PlayerPrefs.Save();
        }
        pauseGame.IsLevel = true;
    }
}
