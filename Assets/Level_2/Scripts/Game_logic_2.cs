using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic_2 : MonoBehaviour
{
    public Text text_Info;
    public Text text_Bonus_Info;
    public Text text_No_Next_Level;
    public int collect;
    public GameObject Battery_Ch;
    public GameObject Task_Ch;
    public GameObject Wall;
    public GameObject Task_Cube;
    public GameObject Next_Level_Cube;

    int count_Bonus_this_scene = 0;
    int count_Collect_Battery = 0;

    bool Done_NPC = false;
    public GameObject NPC_Dead_Ch;
    public Text text_NPC_Dead_Info;
    private int AllCountNPC;
    private int oldcountnpc;
    NPCHelper npcHelper;

   
    // Start is called before the first frame update
    void Start()
    {
        npcHelper = GameObject.Find("NPC").GetComponent<NPCHelper>();
        AllCountNPC = npcHelper.countNPConScene;
        text_NPC_Dead_Info.text = "0/" + AllCountNPC.ToString();
        text_No_Next_Level.gameObject.SetActive(false);
        text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();
        text_Bonus_Info.text = (PlayerPrefs.GetInt("CountBonus") + count_Bonus_this_scene).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (!Done_NPC)
        {
            if(oldcountnpc!=npcHelper.countNPConScene)
            {
                oldcountnpc = npcHelper.countNPConScene;
                text_NPC_Dead_Info.text = (AllCountNPC - oldcountnpc).ToString() + "/" + AllCountNPC.ToString();
                if (oldcountnpc == 0)
                {
                    NPC_Dead_Ch.SetActive(true);
                    Done_NPC = true;
                }
            }
        }
    }

    private void goScene3()
    {
        PlayerPrefs.SetInt("CountBonus", count_Bonus_this_scene+PlayerPrefs.GetInt("CountBonus"));
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(NextLevel);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
        {
            text_No_Next_Level.gameObject.SetActive(false); 
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.SetActive(false);
            Task_Cube.gameObject.SetActive(true);
            Next_Level_Cube.gameObject.SetActive(true);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Easter egg"))
        {
            
            Task_Ch.SetActive(true);

        }
        if (other.gameObject.CompareTag("Next_Level"))
        {
            goScene3();

        }
        if (other.gameObject.CompareTag("Check_Task"))
        {
            if (Battery_Ch.activeInHierarchy == true && NPC_Dead_Ch.activeInHierarchy==true)
                Wall.SetActive(false);
            if (Battery_Ch.activeInHierarchy == true && NPC_Dead_Ch.activeInHierarchy == false)
            {
            text_No_Next_Level.text = "RS1, ты ещё не учичтожил всех членов отряда ОС!\nСначала уничтожь всех, потом возвращайся!";
            text_No_Next_Level.gameObject.SetActive(true);
            }
            if (NPC_Dead_Ch.activeInHierarchy == true && Battery_Ch.activeInHierarchy == false)
            {
            text_No_Next_Level.text = "RS1, ты ещё не собрал необходимое количество батареек!\nВернись и собери хотя бы 20!";
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
}
