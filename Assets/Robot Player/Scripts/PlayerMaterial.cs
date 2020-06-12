using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    public GameObject Body;
    public GameObject LeftPlate;
    public GameObject RearPlate;
    public GameObject RightPlate;
    public GameObject eyeLid;
    
    public Material[] mat;
    // Start is called before the first frame update
    void Start()
    {
        Material(PlayerPrefs.GetInt("MaterialPlayer")); 
    }
    private void Material(int materialN)
    {
        Body.GetComponent<MeshRenderer>().material = mat[materialN];
        LeftPlate.GetComponent<MeshRenderer>().material = mat[materialN];
        RearPlate.GetComponent<MeshRenderer>().material = mat[materialN];
        RightPlate.GetComponent<MeshRenderer>().material = mat[materialN];
        eyeLid.GetComponent<MeshRenderer>().material = mat[materialN];
    }
    
}
