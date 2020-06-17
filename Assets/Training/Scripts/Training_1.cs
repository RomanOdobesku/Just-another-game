using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_1 : MonoBehaviour
{
    private int step = 0;
    public GameObject[] texts;
    public GameObject button;

    private float prevHealthNPC;
    public GameObject NPC;
    public GameObject MedicineCabinet;
    private GameObject Player;
    public Camera camera;

    private bool[] WASD = new bool[4];
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Robot Player");
    }
    public void Click()
    {
        step++;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(step);
        switch (step)
        {
            case 0:
                
                if (Input.GetKeyDown(KeyCode.W))
                {
                    WASD[0] = true;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    WASD[1] = true;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    WASD[2] = true;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    WASD[3] = true;
                }
                bool go = true;
                foreach (var item in WASD)
                {
                    if (item != true)
                    {
                        go = false;
                        break;
                    }
                }
                if (go)
                    step++;
                break;
            case 1:
                texts[0].SetActive(false);
                texts[1].SetActive(true);
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    step++;
                }
                break;
            case 2:
                texts[1].SetActive(false);
                texts[2].SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    step++;
                    NPC.SetActive(true);
                    prevHealthNPC = NPC.GetComponent<HealthHelper>()._health;
                }
                break;
            case 3:
                texts[2].SetActive(false);
                texts[3].SetActive(true);
                NPC.SetActive(true);
                if (prevHealthNPC - NPC.GetComponent<HealthHelper>()._health > 0.1)
                    step++;
                else
                    prevHealthNPC = NPC.GetComponent<HealthHelper>()._health;
                break;
            case 4:
                texts[3].SetActive(false);
                texts[4].SetActive(true);
                if (NPC == null)
                {
                    step++;
                    MedicineCabinet.SetActive(true);
                }
                break;
            case 5:
                texts[4].SetActive(false);
                texts[5].SetActive(true);
                if (prevHealthNPC - Player.GetComponent<HealthHelper>()._health < -1)
                {
                    step++;
                    texts[5].SetActive(false);
                    texts[6].SetActive(true);
                    StartCoroutine(NextTraining());
                }
                else
                    prevHealthNPC = Player.GetComponent<HealthHelper>()._health;
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
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(19);
        yield return null;
    }
}
