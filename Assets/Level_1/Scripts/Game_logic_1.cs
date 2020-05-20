using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic_1 : MonoBehaviour
{

    GameObject[] Medicime_Cabinets;
    List<bool> Active_L = new List<bool>();
    List<float> Timer_L = new List<float>();
    public float _Time;

    public Text text_Info;
    public Text text_Bonus_Info;
    public Text text_No_Next_Level;
    public Text text_Use_Game;
    public int collect;
    public GameObject Battery_Ch;
    public GameObject Task_Ch;
    public GameObject Wall;
    public GameObject[] batterгies;

    int count_Bonus_this_scene = 0;

    int count_Collect_Battery=0;
    bool InEasterEgg = false;
    
    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        Medicime_Cabinets = GameObject.FindGameObjectsWithTag("Medicine cabinet");
        text_No_Next_Level.gameObject.SetActive(false);
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            Active_L.Add(true);
            Timer_L.Add(_Time);
            Medicime_Cabinets[i].SetActive(true);
        }
        text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();
        for (j = 0; j < 15; j++)
        {
            batterгies[j].SetActive(true);
        }
        j = 15;
    }

    void Update()
    {
        if (InEasterEgg)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Загружаем тетрис");
                //возможно вместо перехода на другую сцену, повесим тетрис на UI
               // SceneManager.LoadScene("Tetris");
            }

        }
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

    }

    private void goScene2()
    {
        Const_and_other.count_Bonus+= count_Bonus_this_scene;
        SceneManager.LoadScene("Improvement_Menu"); // Level_2
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
            text_No_Next_Level.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Easter egg"))
        {
            text_Use_Game.gameObject.SetActive(false);
            InEasterEgg = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Easter egg"))
        {
            Task_Ch.SetActive(true);
            text_Use_Game.gameObject.SetActive(true);
            InEasterEgg = true;

        }
        if (other.gameObject.CompareTag("Next_Level"))
        {
            goScene2();

        }
        if (other.gameObject.CompareTag("Check_Task"))
        {
            if (Battery_Ch.activeInHierarchy == true)
                Wall.SetActive(false);
            else
                text_No_Next_Level.gameObject.SetActive(true);


        }
        if (other.gameObject.CompareTag("Repair kit"))
        {
            other.gameObject.SetActive(false);
            count_Bonus_this_scene++;
            text_Bonus_Info.text = (Const_and_other.count_Bonus+ count_Bonus_this_scene).ToString();
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            if (j < 30)
            {
                batterгies[j].SetActive(true);
                j++;
            }
           
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
