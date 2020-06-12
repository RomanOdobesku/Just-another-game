using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class SpawnerBlock : MonoBehaviour
{
    public SpawnerBlock instance;
    public GameObject[] Block;
    public GameObject GameOverMenuUi;
    public GameObject PauseMenuUi;
    public Text txt;
    //public Text hscore;
    public Text End_txt;
    public GameObject text;
    
    public int point;
    public int predpoint;
    public int[] Record;
    public double fallTime=1;
    public int i;

    public bool ChangeRecord;
    public int game;
    public bool pauseMenu;
    
      
    private void Awake()
    {
        Record = new int[5];
        instance = this;
        Time.timeScale = 1;
    }

    void Start()
    { 
        point = 0;
        predpoint = 0;
        game = 1;
        i = 0;

        pauseMenu = false;
        ChangeRecord = false;
        txt.text = "Score: " + point;
    }

    private void Update()
    {
        if(predpoint >= 50){
            predpoint -= 50;
            if (fallTime >= 0.9) fallTime -= 0.004;
            else if (fallTime < 0.9 && fallTime >= 0.8) fallTime -= 0.002;
            else if (fallTime< 0.8 && fallTime >= 0.7) fallTime -= 0.001;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu)
            {
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PauseMenuUi.SetActive(true);
                Time.timeScale = 0;
                pauseMenu = true;
            }
        }

        if(game == 0)
        {
            GameIsOver();
        }
        else
        {
            if (ChangeRecord)
            {
                txt.text = "Score: " + point;
                ChangeRecord = false;
            }
        }
    }

    public void NewBlock()
    {
        Instantiate(Block[Random.Range(0, Block.Length)], transform.position, Quaternion.identity);
    }


    public void GameIsOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameOverMenuUi.SetActive(true);
        Time.timeScale = 0;
        pauseMenu = true;
        text.SetActive(false);
        End_txt.text = "Score: " + point;
    }

    public void Exit_Game()
    {

        PauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        pauseMenu = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
    public void GoMainGame()
    {
        Again();
        pauseMenu = false;
        PauseMenuUi.SetActive(false);
        GameObject.Find("Check_Easter_Egg_Cube").GetComponent<Tetris_Helper>().LoadInGame();
        
    }

    public void Again()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tetris_Block");
        foreach (GameObject item in gameObjects)
        {
            Destroy(item);
        }
        beforeAgain();
        NewBlock();
    }
    private void beforeAgain()
    {
        GameOverMenuUi.SetActive(false);
        point = 0;
        predpoint = 0;
        game = 1;
        i = 0;
        Time.timeScale = 1;
        pauseMenu = false;
        ChangeRecord = false;
        txt.text = "Score: 0";
        txt.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Tetris_Block").GetComponent<TetrisBlock>().Clear();
    }
}
    