using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHelper : MonoBehaviour
{
    public int countNPConScene;
    public int countNPCAlies=0;
    public bool battery = true;

    public GameObject prefab=null;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("NPC Allies") != null)
        {
            countNPCAlies = GameObject.Find("NPC Allies").transform.childCount;
        }
        countNPConScene = GameObject.FindGameObjectsWithTag("Robot").Length-countNPCAlies;
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
    public void DeadUsualNPC()
    {
        countNPConScene--;
    }
    public void DeadEliteNPC(Transform tr)
    {
        DeadUsualNPC();
        if(!battery)
            Instantiate(prefab, new Vector3(tr.position.x-3, tr.position.y, tr.position.z), Quaternion.Euler(90,0,0));
    }
    public void DeadAlies()
    {
        countNPCAlies--;
    }
    public void FindNPC()
    {
        countNPConScene = GameObject.FindGameObjectsWithTag("Robot").Length;
    }
}
