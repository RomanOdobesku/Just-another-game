using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckQRCode : MonoBehaviour
{
    private GameObject CameraBase;
    public GameObject GetPhone;
    private bool IsTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        CameraBase = GameObject.Find("Camera base");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTrigger)
        {
            float rotYCB = CameraBase.transform.rotation.ToEulerAngles().y;
            float rotXCB = CameraBase.transform.rotation.ToEulerAngles().x;
            float rotYGO = gameObject.transform.rotation.ToEulerAngles().y;
            if ((rotXCB< Mathf.PI / 12&& rotXCB >Mathf.PI /(-36))&&((rotYCB < rotYGO + Mathf.PI / 6 && rotYCB > rotYGO - Mathf.PI / 6) || (rotYCB < rotYGO * (-1) + Mathf.PI / 6 && rotYCB > rotYGO * (-1) - Mathf.PI / 6)))
                GetPhone.SetActive(true);
            else
            {
                GetPhone.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {
            IsTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot Player"))
        {

            IsTrigger = false;
            GetPhone.SetActive(false);
        }
    }
}
