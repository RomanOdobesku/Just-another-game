using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMenu : MonoBehaviour
{
    private bool _active = false;
    private GameObject _mainCircle;
    private GameObject[] _text = new GameObject[4];
    private GameObject[] _items = new GameObject[4];
    public bool Active
    {
        set
        {
            _active = value;
            _mainCircle.SetActive(value);
            foreach(GameObject i in _text)
            {
                i.SetActive(value);
            }
            if (!value) 
                foreach(GameObject i in _items)
                {
                    i.SetActive(value);
                }
        }
        get => _active;
    }

    private void Start()
    {
        _mainCircle = transform.Find("Main_Circle").gameObject;

        _text[0] = transform.Find("Upper_Item_T").gameObject;
        _text[1] = transform.Find("Right_Item_T").gameObject;
        _text[2] = transform.Find("Lower_Item_T").gameObject;
        _text[3] = transform.Find("Left_Item_T").gameObject;

        _items[0] = transform.Find("Upper_Item").gameObject;
        _items[1] = transform.Find("Right_Item").gameObject;
        _items[2] = transform.Find("Lower_Item").gameObject;
        _items[3] = transform.Find("Left_Item").gameObject;

        Active = _active;
    }

    public void ActiveItem(int i)
    {
        for (int j = 0; j < 4; ++j)
            if (j != i)
                _items[j].SetActive(false);
        _items[i].SetActive(true);
    }

    public void DisableItems()
    {
        foreach (GameObject i in _items)
            i.SetActive(false);
    }
}
