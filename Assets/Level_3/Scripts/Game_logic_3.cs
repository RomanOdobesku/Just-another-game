using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic_3 : MonoBehaviour
{
    public Text text_Info_main_crystal;
    public GameObject Main_crystal;
    public Text text_Info_add_crystal;
    public Text text_Bonus_Info;
    public Text text_No_Next_Level;
    public int collect_crystal = 20;
    public GameObject Crystal_main_Ch;
    public GameObject Crystal_add_Ch;
    public GameObject Task_Ch;
    public GameObject Wall;

    int count_Bonus_this_scene = 0;
    int count_Collect_add_Crystal = 0;

    GameObject[] Medicime_Cabinets;
    //List<bool> Active_L = new List<bool>();
    List<float> Timer_L = new List<float>();
    public float _Time;
    // Start is called before the first frame update
    void Start()
    {
        Medicime_Cabinets = GameObject.FindGameObjectsWithTag("Medicine cabinet");
        text_No_Next_Level.gameObject.SetActive(false);
        text_Info_main_crystal.text = "0/1";
        text_Info_add_crystal.text = count_Collect_add_Crystal.ToString() + "/" + collect_crystal.ToString();
        text_Bonus_Info.text = (Const_and_other.count_Bonus + count_Bonus_this_scene).ToString();
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            //Active_L.Add(true);
            Timer_L.Add(_Time);
            Medicime_Cabinets[i].SetActive(true);
        }

    }
    private void goScene4()
    {
        // Debug.Log("Перешли на 4 уровень");
        Const_and_other.count_Bonus += count_Bonus_this_scene;
        SceneManager.LoadScene("Improvement_Menu"); // Level_4
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Medicime_Cabinets.Length; i++)
        {
            //if (Active_L[i] == false)
            if (Medicime_Cabinets[i].activeSelf == false)
            {
                if (Timer_L[i] > 0)
                    Timer_L[i] -= Time.deltaTime;
                if (Timer_L[i] <= 0)
                {
                    Medicime_Cabinets[i].SetActive(true);
                    //Active_L[i] = true;
                    Timer_L[i] = _Time;
                }
            }
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
            goScene4();

        }

        if (other.gameObject.CompareTag("Check_Task"))
        {
            if (Crystal_main_Ch.activeInHierarchy == true && Crystal_add_Ch.activeInHierarchy == true)
                Wall.SetActive(false);
            else
                text_No_Next_Level.gameObject.SetActive(true);


        }
        if (other.gameObject.CompareTag("Repair kit"))
        {
            other.gameObject.SetActive(false);
            count_Bonus_this_scene++;
            text_Bonus_Info.text = (Const_and_other.count_Bonus + count_Bonus_this_scene).ToString();
        }

        if (other.gameObject.CompareTag("Crystal_small"))
        {
            Destroy(other.gameObject);

            count_Collect_add_Crystal++;
            if (count_Collect_add_Crystal == collect_crystal)
            {
               Crystal_add_Ch.SetActive(true);
            }
            text_Info_add_crystal.text = count_Collect_add_Crystal.ToString() + "/" + collect_crystal.ToString();
        }
        if (other.gameObject.CompareTag("Crystal_big"))
        {
            Main_crystal.SetActive(false);
            Crystal_main_Ch.SetActive(true);
            text_Info_main_crystal.text = "1/1";
        }

        /*if (other.gameObject.CompareTag("Medicine cabinet"))
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

        }*/

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
            text_No_Next_Level.gameObject.SetActive(false);
    }
}
