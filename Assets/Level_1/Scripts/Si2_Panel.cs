using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Si2_Panel : MonoBehaviour
{
    public GameObject Si2Panel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Panel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Panel()
    {
        yield return new WaitForSeconds(5);
        Si2Panel.SetActive(true);
        yield return new WaitForSeconds(8);
        Si2Panel.SetActive(false);
        yield return null;
    }
}
