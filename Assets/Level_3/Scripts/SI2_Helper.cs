using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SI2_Helper : MonoBehaviour
{
    public GameObject SI2_Panel;
    public GameObject BlueField;
    bool ActiveBlueField=false;
    public GameObject RedField;
    bool ActiveRedField = false;
    GameObject Field;
    public float Timer=8;
    // Start is called before the first frame update
    void Start()
    {
        SI2_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer<=0 && Field != null)
        {
            SI2_Panel.SetActive(false);
            Field.SetActive(false);
            Field = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Field Blue Check") && ActiveBlueField == false && other.CompareTag("Robot Player"))
        {
            SI2_Panel.SetActive(true);
            Field = BlueField;
            Field.SetActive(true);
            ActiveBlueField = true;
            Timer = 8;
            
        }
        if (this.CompareTag("Field Red Check") && ActiveRedField == false && other.CompareTag("Robot Player"))
        {
            SI2_Panel.SetActive(true);
            Field = RedField;
            Field.SetActive(true);
            ActiveRedField = true;
            Timer = 8;
        }
    }
    
}
