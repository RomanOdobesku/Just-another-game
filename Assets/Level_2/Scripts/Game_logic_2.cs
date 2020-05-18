using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic_2 : MonoBehaviour
{
    GameObject[] Medicime_Cabinets;
    List<bool> Active_L = new List<bool>();
    List<float> Timer_L = new List<float>();
    public float _Time;

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

    GameObject[] NPC;
    bool Done_NPC = false;
    public GameObject NPC_Dead_Ch;
    public Text text_NPC_Dead_Info;

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.FindGameObjectsWithTag("Robot");
        Medicime_Cabinets = GameObject.FindGameObjectsWithTag("Medicine cabinet");
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            Active_L.Add(true);
            Timer_L.Add(_Time);
            Medicime_Cabinets[i].SetActive(true);
        }
        text_NPC_Dead_Info.text = "0/" + NPC.Length.ToString();
        text_No_Next_Level.gameObject.SetActive(false);
        text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            if (Active_L[i] == false)
            {
                if (Timer_L[i] > 0)
                    Timer_L[i] -= Time.deltaTime;
                if (Timer_L[i] <= 0)
                {
                    Medicime_Cabinets[i].SetActive(true);
                    Active_L[i] = true;
                    Timer_L[i] = _Time;
                }
            }
        }
        if (!Done_NPC)
        {
            int count_NPC = NPC.Length;
            foreach (GameObject NPC_r in NPC)
            {

                if (NPC_r.gameObject == null)
                    count_NPC--;
            }
            text_NPC_Dead_Info.text = (NPC.Length - count_NPC).ToString()+"/"+ NPC.Length.ToString() ;
            if (count_NPC == 0)
            {
                NPC_Dead_Ch.SetActive(true);
                Done_NPC = true;
            }
        }

    }

    private void goScene3()
    {
        Const_and_other.count_Bonus += count_Bonus_this_scene;
        SceneManager.LoadScene("Improvement_Menu"); // Level_3
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
        {
            text_No_Next_Level.gameObject.SetActive(false);
            
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.SetActive(false);
            Task_Cube.gameObject.SetActive(true);
            Next_Level_Cube.gameObject.SetActive(true);
        }
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
            if (NPC_Dead_Ch.activeInHierarchy == true)
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
            text_Bonus_Info.text = (Const_and_other.count_Bonus + count_Bonus_this_scene).ToString();
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

        if (other.gameObject.CompareTag("Medicine cabinet"))
        {
            for (int i = 0; i < Medicime_Cabinets.Length; i++)
            {
                if (other.name == Medicime_Cabinets[i].name)
                {
                    other.gameObject.SetActive(false);
                    Active_L[i] = false;
                    break;
                }
            }
        }
    }
}
