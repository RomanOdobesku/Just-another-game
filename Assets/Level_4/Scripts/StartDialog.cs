using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialog : MonoBehaviour
{
    public GameObject SI2Image;
    public GameObject AGImage;
    public GameObject BackGroundFriend;
    public GameObject BackgroundRS;
    public GameObject[] texts;

    public GameObject Player;
    public GameObject NPC;

    private int numberClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        switch (numberClick)
        {
            case 0:
                Click1();
                break;
            case 1:
                Click2();
                break;
            case 2:
                Click3();
                break;
            case 3:
                Click4();
                break;
            case 4:
                Click5();
                break;
            case 5:
                Click6();
                break;
            case 6:
                Click7();
                break;
            case 7:
                Click8();
                break;
            case 8:
                Click9();
                break;
            default:
                break;
        }
        numberClick++;
    }
    private void Click1()
    {
        SI2Image.SetActive(false);
        texts[0].SetActive(false);
        BackGroundFriend.SetActive(false);
        BackgroundRS.SetActive(true);
        texts[1].SetActive(true);
    }
    private void Click2()
    {
        texts[1].SetActive(false);
        texts[2].SetActive(true);
    }
    private void Click3()
    {
        BackgroundRS.SetActive(false);
        texts[2].SetActive(false);
        BackGroundFriend.SetActive(true);
        SI2Image.SetActive(true);
        texts[3].SetActive(true);
    }
    private void Click4()
    {
        texts[3].SetActive(false);
        SI2Image.SetActive(false);
        AGImage.SetActive(true);
        texts[4].SetActive(true);

    }
    private void Click5()
    {
        AGImage.SetActive(false);
        texts[4].SetActive(false);
        BackGroundFriend.SetActive(false);
        BackgroundRS.SetActive(true);
        texts[5].SetActive(true);
    }
    private void Click6()
    {
        BackgroundRS.SetActive(false);
        texts[5].SetActive(false);
        BackGroundFriend.SetActive(true);
        SI2Image.SetActive(true);
        texts[6].SetActive(true);
    }
    private void Click7()
    {
        SI2Image.SetActive(false);
        texts[6].SetActive(false);
        AGImage.SetActive(true);
        texts[7].SetActive(true);
    }
    private void Click8()
    {
        AGImage.SetActive(true);
        texts[7].SetActive(false);
        BackGroundFriend.SetActive(false);
        BackgroundRS.SetActive(true);
        texts[8].SetActive(true);
    }
    private void Click9()
    {
        BackgroundRS.SetActive(false);
        NPC.SetActive(true);
        Player.SetActive(true);
       
        this.gameObject.SetActive(false);
    }
}
