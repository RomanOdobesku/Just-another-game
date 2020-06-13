using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_logic_5 : MonoBehaviour
{
    public GameObject Keeper_Ch;
    private GameObject Keeper;
    public GameObject FollowObjectPlayer;
    public GameObject PanelRebot;
    public GameObject Reboot_Ch;
    public GameObject adviceAG;

    public GameObject NPCFollowPlayer;
    public GameObject NPCRE;
    public GameObject NPCREe;
    private GameObject NPCЕnemy;


   
    // Start is called before the first frame update
    void Start()
    {
        Keeper = GameObject.Find("Keeper");
        NPCЕnemy = GameObject.Find("NPC Enemy");
    }
    public void goScene6()
    {
        GameObject LoadingPanel = GameObject.Find("Loading Panel");
        LoadingPanel.transform.GetChild(0).gameObject.SetActive(true);
        int NextLevel = PlayerPrefs.GetInt("NextLevel");
        NextLevel++;
        PlayerPrefs.SetInt("NextLevel", NextLevel);
        PlayerPrefs.Save();
        LoadingPanel.transform.GetChild(0).gameObject.GetComponent<Loading>().LoadScene(NextLevel);
    }
    // Update is called once per frame
    void Update()
    {
        if (Keeper_Ch.activeInHierarchy == false)
        {
            if (Keeper != null)
            {
                if (NPCЕnemy.transform.childCount == 0)
                {
                    GameObject NPC;
                    NPC=Instantiate(NPCRE, new Vector3(234.5235f, 76.20984f, 469.2239f),Quaternion.identity,NPCЕnemy.transform);
                    NPC.GetComponent<NPCFollow>().FollowObject = NPCFollowPlayer.transform;
                    NPC = Instantiate(NPCRE, new Vector3(-915.6765f, 151.2098f, 2168.524f), Quaternion.identity, NPCЕnemy.transform);
                    NPC.GetComponent<NPCFollow>().FollowObject = NPCFollowPlayer.transform;
                    NPC = Instantiate(NPCREe, new Vector3(656.7635f, 143.5499f, 1512.394f), Quaternion.identity, NPCЕnemy.transform);
                    NPC.GetComponent<NPCFollow>().FollowObject = NPCFollowPlayer.transform;
                }
            }
            else
            {
                Keeper_Ch.SetActive(true);
                PanelRebot.SetActive(true);
                adviceAG.SetActive(true);
                for (int i = 0; i < NPCЕnemy.transform.childCount; i++)
                {
                    NPCЕnemy.transform.GetChild(i).GetComponent<HealthHelper>().GetDamage(200, null);
                }
                Invoke("CloseAGPanel", 8);

            }
        }
    }
    private void CloseAGPanel()
    {
        adviceAG.SetActive(false);
    }
    
}
