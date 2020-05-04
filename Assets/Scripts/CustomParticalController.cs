using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomParticalController : MonoBehaviour
{
    private ParticleSystem.EmissionModule _dustEmission;
    private ParticleSystem.EmissionModule _rockEmission;

    void Start()
    {
        _dustEmission = GetComponent<ParticleSystem>().emission;
        _rockEmission = transform.GetChild(0).GetComponent<ParticleSystem>().emission;
    }

    public bool Enabled
    {
        set
        {
            _dustEmission.enabled = value;
            _rockEmission.enabled = value;
        }
    }
}
