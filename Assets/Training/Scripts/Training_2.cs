using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Training_2 : MonoBehaviour
{
    private int step = 0;
    public GameObject[] texts;

    private float prevHealthNPC;
    public GameObject NPC;
    public GameObject MedicineCabinet;
    public GameObject MedicineCabinetObject;

    private bool click_ctrl = false;

    private bool TaskAtack = false;
    private bool TaskB = false;

    private float[] prevHealthNPCAllies = new float[4];

    private GameObject Allies;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Robot Player");
        Allies = GameObject.Find("NPC Allies");
    }
    public void Click()
    {
        step++;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Allies.transform.childCount; i++)
        {
            if (Allies.transform.GetChild(i).GetComponent<HealthHelper>()._health <= 10)
                Allies.transform.GetChild(i).GetComponent<HealthHelper>()._health = 100;
        }
        if (Player.GetComponent<HealthHelper>()._health <= 10)
            Player.GetComponent<HealthHelper>()._health = 100;
        Debug.Log(step);
        switch (step)
        {
            case 0:

                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    step++;
                    texts[0].SetActive(false);
                    texts[1].SetActive(true);
                }  
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    click_ctrl = true;
                    
                }
                if (Input.GetMouseButtonDown(0) && click_ctrl)
                {
                    for (int i = 0; i < Allies.transform.childCount; i++)
                    {
                        Allies.transform.GetChild(i).GetComponent<HealthHelper>()._health = 50;
                    }
                    step++;
                    texts[1].SetActive(false);
                    texts[2].SetActive(true);
                    MedicineCabinet.SetActive(true);
                }
                break;
            case 2:
                if (MedicineCabinetObject.activeInHierarchy == false)
                {
                    step++;
                    texts[2].SetActive(false);
                    texts[3].SetActive(true);
                    MedicineCabinet.SetActive(false);
                    NPC.SetActive(true);
                    for (int i = 0; i < Allies.transform.childCount; i++)
                    {
                        prevHealthNPCAllies[i]= Allies.transform.GetChild(i).GetComponent<HealthHelper>()._health=100;
                        
                    }
                    prevHealthNPC = NPC.GetComponent<HealthHelper>()._health;
                }
                break;
            case 3:
                bool nextStep = false;
                for (int i = 0; i < Allies.transform.childCount; i++)
                {
                    if (prevHealthNPCAllies[i] - Allies.transform.GetChild(i).GetComponent<HealthHelper>()._health > 0.2 && prevHealthNPC - NPC.GetComponent<HealthHelper>()._health>0.2)
                    {
                        nextStep = true;
                        break;
                    }
                }
                if (nextStep)
                {
                    step++;
                    texts[3].SetActive(false);
                    texts[4].SetActive(true);
                    NPC.GetComponent<HealthHelper>().DamagePerSecond = 0;
                }
                else
                {
                    for (int i = 0; i < Allies.transform.childCount; i++)
                    {
                        prevHealthNPCAllies[i] = Allies.transform.GetChild(i).GetComponent<HealthHelper>()._health = 100;
                    }
                    prevHealthNPC = NPC.GetComponent<HealthHelper>()._health;
                }
                break;
            case 4:
                NPC.GetComponent<HealthHelper>().DamageRobotSensivity = 0;
                if (TaskAtack)
                {
                    texts[4].SetActive(false);
                    texts[5].SetActive(true);
                    step++;
                }
                break;
            case 5:
                NPC.GetComponent<HealthHelper>().DamageRobotSensivity = 0.1f;
                if (NPC.GetComponent<HealthHelper>()._health <= 10)
                    NPC.GetComponent<HealthHelper>()._health = 100;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    texts[5].SetActive(false);
                    texts[6].SetActive(true);
                    step++;
                }
                
                break;
            case 6:
                if (TaskB)
                {
                    texts[6].SetActive(false);
                    texts[7].SetActive(true);
                    step++;
                    StartCoroutine(NextTraining());
                }

                break;
            default:
                break;
        }
    }
    IEnumerator NextTraining()
    {
        yield return new WaitForSeconds(5);
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(20);
        yield return null;
    }
    
    public void DoTaskaAtack()
    {
        TaskAtack = true;
    }
    public void DoTaskB()
    {
        TaskB = true;
    }
}
