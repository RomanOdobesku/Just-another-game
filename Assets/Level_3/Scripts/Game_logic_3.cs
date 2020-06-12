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
    public GameObject Wall;

    int count_Bonus_this_scene = 0;
    int count_Collect_add_Crystal = 0;

    // Start is called before the first frame update
    void Start()
    {
        text_No_Next_Level.gameObject.SetActive(false);
        text_Info_main_crystal.text = "0/1";
        text_Info_add_crystal.text = count_Collect_add_Crystal.ToString() + "/" + collect_crystal.ToString();
        text_Bonus_Info.text = (PlayerPrefs.GetInt("CountBonus") + count_Bonus_this_scene).ToString();

    }
    public void goScene4()
    {
        PlayerPrefs.SetInt("CountBonus", count_Bonus_this_scene + PlayerPrefs.GetInt("CountBonus"));
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(NextLevel);
    }
    // Update is called once per frame
   

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Next_Level"))
        {
            if (gameObject.GetComponent<EasterEgg3>().FindEA == true)
            {
                gameObject.GetComponent<EasterEgg3>().EndLevelMethod();
                gameObject.GetComponent<EasterEgg3>().OpenPanel();
            }
            else
            {
                goScene4();
            }
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
            text_Bonus_Info.text = (PlayerPrefs.GetInt("CountBonus") + count_Bonus_this_scene).ToString();
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Check_Task"))
            text_No_Next_Level.gameObject.SetActive(false);
    }
}
