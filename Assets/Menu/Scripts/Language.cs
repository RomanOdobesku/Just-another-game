using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public Dropdown dropdown;
   // public Text text_l;
   // public Text _Main_menu_T;
    public Text _Start_campany_T;
    public Text _Start_campany_T_Help;
    public Text _Start_fight_T;
    public Text _Start_fight_T_Help;
    public Text _Settings_T;
    public Text _Settings_T_Help;
    public Text _Exit_T;
    public Text _Exit_T_Help;
    public Text _Setting_Menu_T;
    public Text _Graphics_T;
    public Dropdown _Graphics_D;
    public Text _Language_T;
    public Text _Back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dropdown.captionText.text == "English")
        {
           // _Main_menu_T.text = "Main menu";
            _Start_campany_T.text = "Campania";
            _Start_campany_T_Help.text= "Start fighting \nwith the Absolute";
            _Start_fight_T.text = "Team play";
            _Start_fight_T_Help.text = "Start commanding team\nup and defeat the RQ";
            _Settings_T.text = "Settings";
            _Settings_T_Help.text = "Graphic settings \nand language selection";
            _Exit_T.text = "Exit the game";
            _Exit_T_Help.text = "Leaving already? \nWho will fight?";
            _Setting_Menu_T.text="Settings";
            _Graphics_T.text = "Graphics Quality";
            _Graphics_D.options[0].text = "Low";
            _Graphics_D.options[1].text = "Medium";
            _Graphics_D.options[2].text = "High";
            _Graphics_D.options[3].text = "Ultra";
            _Language_T.text = "Language";
            _Back.text = "Back";
            
        }
        if (dropdown.captionText.text == "Русский")
        {
          //  _Main_menu_T.text = "Главное меню";
            _Start_campany_T.text = "Кампания";
            _Start_campany_T_Help.text = "Начните сражаться \nс Абсолютом";
            _Start_fight_T.text = "Командная игра";
            _Start_fight_T_Help.text = "Начните командовать \nотрядом и победите ОС";
            _Settings_T.text = "Настройки";
            _Settings_T_Help.text = "Настройки графики \nи выбор языка";
            _Exit_T.text = "Выйти из игры";
            _Exit_T_Help.text = "Уже уходите? \nА кто будет сражаться?";
            _Setting_Menu_T.text = "Настройки";
            _Graphics_T.text = "Качество графики";
            _Graphics_D.options[0].text = "Низкое";
            _Graphics_D.options[1].text = "Среднее";
            _Graphics_D.options[2].text = "Высокое";
            _Graphics_D.options[3].text = "Ультра";
            _Language_T.text = "Язык";
            _Back.text = "Назад";
        }
    }
}