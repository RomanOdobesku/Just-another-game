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
    // Start is called before the first frame update
    void Start()
    {
        SI2_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        GameObject parent = obj.transform.parent.gameObject;
        if (this.CompareTag("Field Blue Check") && ActiveBlueField == false && (obj.CompareTag("Robot Player") || parent.CompareTag("Robot Player")))
        {
            SI2_Panel.SetActive(true);
            BlueField.SetActive(true);
            ActiveBlueField = true;
            
        }
        if (this.CompareTag("Field Red Check") && ActiveRedField == false && (obj.CompareTag("Robot Player") || parent.CompareTag("Robot Player")))
        {
            SI2_Panel.SetActive(true);
            RedField.SetActive(true);
            ActiveRedField = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        GameObject parent = obj.transform.parent.gameObject;
        if (this.CompareTag("Field Blue Check") && (obj.CompareTag("Robot Player") || parent.CompareTag("Robot Player")))
        {
            BlueField.SetActive(false);
            SI2_Panel.SetActive(false);

        }
        if (this.CompareTag("Field Red Check") && (obj.CompareTag("Robot Player") || parent.CompareTag("Robot Player")))
        {
            RedField.SetActive(false);
            SI2_Panel.SetActive(false);
        }
    }
}
