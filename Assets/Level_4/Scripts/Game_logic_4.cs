﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic_4 : MonoBehaviour
{
    public Text text_Info;
    public Text text_Bonus_Info;
    public Text text_No_Next_Level;
    public int collect;
    public GameObject Battery_Ch;
    public GameObject Task_Ch;
    public GameObject Wall;
    public GameObject adviceAG;
    public GameObject adviceSI2;
    public GameObject EA_Help;

    int count_Bonus_this_scene = 0;
    int count_Collect_Battery = 0;

    bool Done_NPC = false;
    public GameObject NPCPart2;
    public GameObject NPC_Dead_Ch;
    private int AllCountNPC;
    private int oldCountNPC;
    NPCHelper npcHelper;
    bool newpartNPC = false;
    GameObject EliteNPC;

    public bool InEasterEgg = false;
    private bool NPCEliteKill = false;
    // Start is called before the first frame update
    void Start()
    {
        EliteNPC = GameObject.FindGameObjectWithTag("NPC Elite");
        npcHelper = GameObject.Find("NPC").GetComponent<NPCHelper>();
        AllCountNPC = npcHelper.countNPConScene;
        oldCountNPC = AllCountNPC;
        text_No_Next_Level.gameObject.SetActive(false);
        text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();
        text_Bonus_Info.text = (PlayerPrefs.GetInt("CountBonus") + count_Bonus_this_scene).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Done_NPC)
        {
            if (oldCountNPC != npcHelper.countNPConScene)
            {
                oldCountNPC = npcHelper.countNPConScene;
                if (oldCountNPC == 0)
                {
                    Done_NPC = true;
                    Invoke("StartNPCpart2",5);
                }
                if (EliteNPC == null&& !NPCEliteKill)
                {
                    NPCEliteKill = true;
                    adviceAG.SetActive(true);
                    Invoke("AdviceAG", 7);
                }
            }
        }
        if (Done_NPC && newpartNPC) { 
            if (oldCountNPC != npcHelper.countNPConScene)
            {
                oldCountNPC = npcHelper.countNPConScene;
                if (oldCountNPC == 0)
                {
                    NPC_Dead_Ch.SetActive(true);
                    if (Battery_Ch.activeInHierarchy)
                    {
                        adviceSI2.transform.GetChild(0).GetComponent<Text>().text = "Трансформато,\nмы закончили с ними.\nВозвращайся в лагерь!";
                    }
                    else
                    {
                        adviceSI2.transform.GetChild(0).GetComponent<Text>().text = "Трансформато,\nмы закончили с ними.\nСобирай все батарейки и возвращайся в лагерь!";
                    }
                    adviceSI2.SetActive(true);
                    Invoke("AdviceSI2",7);
                }
            }
        }

    }
    private void goScene5()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        PlayerPrefs.SetInt("CountBonus", PlayerPrefs.GetInt("CountBonus")+count_Bonus_this_scene);
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(NextLevel);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
        {
            text_No_Next_Level.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Easter egg"))
        {
            InEasterEgg = false;
            EA_Help.SetActive(false);
            EA_Help.GetComponent<MusicDevsRoom>().PlayOld = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Easter egg"))
        {
            Task_Ch.SetActive(true);
            InEasterEgg = true;
            EA_Help.SetActive(true);
        }
        if (other.gameObject.CompareTag("Next_Level"))
        {
            goScene5();

        }
        if (other.gameObject.CompareTag("Check_Task"))
        {
            if (Battery_Ch.activeInHierarchy == true && NPC_Dead_Ch.activeInHierarchy == true)
                Wall.SetActive(false);
            if (Battery_Ch.activeInHierarchy == true && NPC_Dead_Ch.activeInHierarchy == false)
            {
                text_No_Next_Level.text = "RS1, ты ещё не учичтожил всех членов отряда ОС!\nУничтожь их всех!";
                text_No_Next_Level.gameObject.SetActive(true);
            }
            if (NPC_Dead_Ch.activeInHierarchy == true && Battery_Ch.activeInHierarchy == false)
            {
                text_No_Next_Level.text = "RS1, ты ещё не собрал необходимое количество батареек!\nВернись и собери хотя бы 10!";
                text_No_Next_Level.gameObject.SetActive(true);
            }
            if (Battery_Ch.activeInHierarchy == false && NPC_Dead_Ch.activeInHierarchy == false)
            {
                text_No_Next_Level.gameObject.SetActive(true);
            }

        }
        if (other.gameObject.CompareTag("Repair kit"))
        {
            other.gameObject.SetActive(false);
            count_Bonus_this_scene++;
            text_Bonus_Info.text = (PlayerPrefs.GetInt("CountBonus") + count_Bonus_this_scene).ToString();
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            count_Collect_Battery++;
            if (count_Collect_Battery == collect)
            {
                Battery_Ch.SetActive(true);
            }
            text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();
        }
    }
    private void StartNPCpart2()
    {
        NPCPart2.SetActive(true);
        npcHelper.FindNPC();
        AllCountNPC = npcHelper.countNPConScene;
        oldCountNPC = AllCountNPC;
        newpartNPC = true;
    }
    private void AdviceSI2()
    {
        adviceSI2.SetActive(false);
    }
    private void AdviceAG()
    {
        adviceAG.SetActive(false);
    }
}
