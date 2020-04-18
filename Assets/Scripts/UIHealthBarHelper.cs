using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarHelper : MonoBehaviour
{
    private Transform _nPC;
    public Transform NPC
    {
        get { return _nPC; }
        set
        {
            _nPC = value;
            _HealthHelper = NPC.GetComponent<HealthHelper>();
            _Slider = GetComponentInChildren<Slider>();
            _Slider.maxValue = _HealthHelper.MaxHealth;
        }
    }

    private float _Height = 0;
    public Camera Cam;
    private bool _IsActive = true;

    public float Height
    {
        set => _Height = value;
    }

    public Camera InitCam
    {
        set
        {
            if (Cam == null)
                Cam = value;
        }
    }

    private Slider _Slider;
    private HealthHelper _HealthHelper;

    Collider objCollider;
    Plane[] planes;
    // Use this for initialization
    void Start()
    {
        objCollider = transform.parent.GetComponentInChildren<SphereCollider>() as Collider;
        print(objCollider);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Cam);
        if (!NPC)
            return;
        Vector3 position = NPC.position;
        position.y += _Height;

        if ((Cam.transform.position - NPC.position).magnitude > 200 || !GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
            Hide();
        else
            Show();
        
        GetComponent<RectTransform>().position = Cam.WorldToScreenPoint(position);
        if (_Slider)
            _Slider.value = _HealthHelper.Health;
    }

    void Hide()
    {
        _Slider.gameObject.SetActive(false);
    }

    void Show()
    {
        _Slider.gameObject.SetActive(true);
    }

    public void DisableSlider()
    {
        Destroy(_Slider.gameObject);
    }
}

