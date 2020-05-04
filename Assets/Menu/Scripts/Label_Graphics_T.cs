using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label_Graphics_T : MonoBehaviour
{
    public Text Label;
    public Text Language_T;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Check_Language()
    {
        if (Language_T.text == "Русский")
        {
            if (Label.text == "Low")
                Label.text = "Низкое";
            if (Label.text == "Medium")
                Label.text = "Среднее";
            if (Label.text == "High")
                Label.text = "Высокое";
            if (Label.text == "Ultra")
                Label.text = "Ультра";

        }
        if (Language_T.text == "English")
        {
            if (Label.text == "Низкое")
                Label.text = "Low";
            if (Label.text == "Среднее")
                Label.text = "Medium";
            if (Label.text == "Высокое")
                Label.text = "High";
            if (Label.text == "Ультра")
                Label.text = "Ultra";
        }
    }
}
