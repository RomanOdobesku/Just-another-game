using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAButtonPos : MonoBehaviour
{
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].transform.localPosition = new Vector2(25 - (Screen.width) / 2 + 80, 70 - (Screen.height) / 2 + 30);
        buttons[2].transform.localPosition = new Vector2(0, 70 - (Screen.height) / 2 + 30);
        buttons[4].transform.localPosition = new Vector2(-25 + (Screen.width) / 2 - 80, 70 - (Screen.height) / 2 + 30);
        buttons[1].transform.localPosition = new Vector2((buttons[0].transform.localPosition.x + buttons[2].transform.localPosition.x) / 2, 70 - (Screen.height) / 2 + 30);
        buttons[3].transform.localPosition = new Vector2((buttons[4].transform.localPosition.x + buttons[2].transform.localPosition.x) / 2, 70 - (Screen.height) / 2 + 30);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
