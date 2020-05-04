using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic : MonoBehaviour
{ 
    
    public GameObject[] Medicime_Cabinets;
    bool[] Active = new bool[7];
    float[] Timer = new float[7];
    public float _Time;

    public Text text_Info;
    public Text text_Bonus_Info;
    public Text text_No_Next_Level;
    public int collect=20;
    public GameObject Battery_Ch;
    public GameObject Task_Ch;
    public GameObject[] batterгies;


    int count_Collect_Battery=0;
    int count_Bonus = 0;
    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        text_No_Next_Level.gameObject.SetActive(false);
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            Timer[i] = _Time;
            Active[i] = true;
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
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            if (Active[i] == false)
            {
                if (Timer[i] > 0)
                    Timer[i] -= Time.deltaTime;
                if (Timer[i] <= 0)
                {
                    Medicime_Cabinets[i].SetActive(true);
                    Active[i] = true;
                    Timer[i] = _Time;
                }
            }
        }
       
    }

    private void goScene2()
    {
        Debug.Log("Перешли на 2 уровень");
       // SceneManager.LoadScene(""); // Level_2
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Next_Level"))
            text_No_Next_Level.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
        {
            Task_Ch.SetActive(true);

        }
        if (other.gameObject.CompareTag("Next_Level"))
        {
            if (Battery_Ch.activeInHierarchy == true)
                goScene2();
            else
                text_No_Next_Level.gameObject.SetActive(true);


        }

        if (other.gameObject.CompareTag("Repair kit"))
        {
            other.gameObject.SetActive(false);
            count_Bonus++;
            text_Bonus_Info.text = count_Bonus.ToString();
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
            if (count_Collect_Battery == 20)
            {
                Battery_Ch.SetActive(true);
            }
            //if (count_Collect_Battery == batterгies.Length)
            //{
            //    text_All_Battery.gameObject.SetActive(true);
            //}
            text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();
        }

        if (other.gameObject.CompareTag("Medicine cabinet"))
        {
            for (int i = 0; i < Medicime_Cabinets.Length; i++)
            {
                if (other.name == Medicime_Cabinets[i].name)
                {
                    other.gameObject.SetActive(false);
                    Active[i] = false;
                    break;
                }
            }

        }

    }

}
