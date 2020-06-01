using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    public float timeWait=30f;
    
    public void ToTackMedCab(GameObject other)
    {
        
        StartCoroutine(StartMedCab(other));
    }
    public IEnumerator StartMedCab(GameObject other)
    {
        other.SetActive(false);
        yield return new WaitForSeconds(timeWait);
        other.SetActive(true);
        yield return null;
    }
}
