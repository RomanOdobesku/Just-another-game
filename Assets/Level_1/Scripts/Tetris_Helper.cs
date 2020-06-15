using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Helper : MonoBehaviour
{
    public GameObject Task_Ch;
    public GameObject text_Use_Game;
    bool InEasterEgg = false;

    public GameObject Canvas_Game;
    public GameObject NPC;
    public GameObject Player;
    public GameObject Tetris_Camera;
    public GameObject Tetris_Spawner;
    public GameObject Tetris_Canvas;
    public GameObject Tetris_Video;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InEasterEgg)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(LoadTetrsis());
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Robot Player"))
        {
            text_Use_Game.gameObject.SetActive(false);
            InEasterEgg = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot Player"))
        {
            Task_Ch.SetActive(true);
            text_Use_Game.gameObject.SetActive(true);
            InEasterEgg = true;

        }
    }
    public void LoadInGame()
    {

        Tetris_Canvas.SetActive(false);
        Player.SetActive(true);
        NPC.SetActive(true);
        Canvas_Game.SetActive(true);
        Tetris_Camera.SetActive(false);
        Tetris_Spawner.SetActive(false);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tetris_Block");
        foreach (GameObject item in gameObjects)
        {
            Destroy(item);
        }

    }
    IEnumerator LoadTetrsis()
    {
        Canvas_Game.SetActive(false);
        NPC.SetActive(false);
        Player.SetActive(false);
        Tetris_Camera.SetActive(true);
        Tetris_Video.SetActive(true);
        yield return new WaitForSeconds(10);
        Tetris_Video.SetActive(false);
        Tetris_Canvas.SetActive(true);
        Tetris_Spawner.SetActive(true);
        GameObject.Find("Spawner").GetComponent<SpawnerBlock>().NewBlock();
        yield return null;
    }
    
}
