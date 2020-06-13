using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight : MonoBehaviour
{
    public GameObject Task_Ch;
    private NPCHelper npcHelper;
    // Start is called before the first frame update
    void Start()
    {
        npcHelper = GameObject.Find("NPC").GetComponent<NPCHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcHelper.countNPConScene == 0 )
        {
            Task_Ch.SetActive(true);
        }
    }
}
