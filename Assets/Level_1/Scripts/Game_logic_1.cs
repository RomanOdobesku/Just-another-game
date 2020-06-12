using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_logic_1 : MonoBehaviour
{
    public Text text_Info;
    public Text text_Bonus_Info;
    public Text text_No_Next_Level;
    public int collect;
    public GameObject Battery_Ch;
    public GameObject Wall;
    public GameObject[] batterгies;

    int count_Bonus_this_scene = 0;

    int count_Collect_Battery=0;

    int j;
 
    // Start is called before the first frame update
    void Start()
    {
        text_No_Next_Level.gameObject.SetActive(false);
        text_Info.text = count_Collect_Battery.ToString() + "/" + collect.ToString();
        for (j = 0; j < 15; j++)
        {
            batterгies[j].SetActive(true);
        }
        j = 15;
    }

    private void GoScene2()
    {
        PlayerPrefs.SetInt("CountBonus", count_Bonus_this_scene);
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(NextLevel);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
            text_No_Next_Level.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Next_Level"))
        {
            GoScene2();

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
            text_Bonus_Info.text = (PlayerPrefs.GetInt("CountBonus") + count_Bonus_this_scene).ToString();
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
    }
}
