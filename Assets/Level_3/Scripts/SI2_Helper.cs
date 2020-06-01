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
        if (this.CompareTag("Field Blue Check") && ActiveBlueField == false && other.CompareTag("Robot Player"))
        {
            StartCoroutine(CoroutineField(BlueField));
        }
        if (this.CompareTag("Field Red Check") && ActiveRedField == false && other.CompareTag("Robot Player"))
        {
            StartCoroutine(CoroutineField(RedField));
        }
    }
    private IEnumerator CoroutineField(GameObject field)
    {
        SI2_Panel.SetActive(true);
        Field = field;
        Field.SetActive(true);
        if (field == BlueField)
            ActiveBlueField = true;
        else
            ActiveRedField = true;
        yield return new WaitForSeconds(8);
        SI2_Panel.SetActive(false);
        Field.SetActive(false);
        Field = null;
        yield return null;
    }
}
