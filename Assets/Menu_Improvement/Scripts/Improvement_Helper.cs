using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Improvement_Helper : MonoBehaviour
{
    public Image _speed;
    int _Speed;
    public Image _health;
    int _Health;
    public Image _damage;
    int _Damage;
    public Text text;
    int _FreeBonus;
    public GameObject prefab;
    int NextLevel;
    // Const_and_other.count_Bonus
    //public int _free_improvement;
    
    // Start is called before the first frame update
    void Start()
    {
        NextLevel = PlayerPrefs.GetInt("NextLevel");
        _Speed = PlayerPrefs.GetInt("Speed");
        _Health = PlayerPrefs.GetInt("Health");
        _Damage = PlayerPrefs.GetInt("Damage");
        _FreeBonus = PlayerPrefs.GetInt("CountBonus");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _speed.fillAmount = 0.2f * _Speed;
        _health.fillAmount = 0.2f * _Health;
        _damage.fillAmount = 0.2f * _Damage;
        text.text = _FreeBonus.ToString();
        if (NextLevel == 5)
        {
            GameObject pref=Instantiate(prefab,GameObject.Find("Canvas").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
    public void Save()
    {
        PlayerPrefs.SetInt("CountBonus",_FreeBonus);
        PlayerPrefs.SetInt("Speed", _Speed);
        PlayerPrefs.SetInt("Health", _Health);
        PlayerPrefs.SetInt("Damage", _Damage);
    }
    public void Plus_Speed()
    {
        if (_FreeBonus > 0 && _Speed < 5)
        {
            _speed.fillAmount += 0.2f;
            _Speed++;
            _FreeBonus--;
            text.text = _FreeBonus.ToString();
        }  
    }
    public void Minus_Speed()
    {
        if (_Speed > 0)
        {
            _speed.fillAmount -= 0.2f;
            _Speed--;
            _FreeBonus++;
            text.text = _FreeBonus.ToString();
        }
        
    }
    public void Plus_Health()
    {
        if (_FreeBonus > 0 && _Health < 5)
        {
            _health.fillAmount += 0.2f;
            _Health++;
            _FreeBonus--;
            text.text = _FreeBonus.ToString();
        }
    }
    public void Minus_Health()
    {
        if (_Health > 0)
        {
            _health.fillAmount -= 0.2f;
            _Health--;
            _FreeBonus++;
            text.text = _FreeBonus.ToString();
        }
    }
    public void Plus_Damage()
    {
        if (_FreeBonus > 0 && _Damage < 5)
        {
            _damage.fillAmount += 0.2f;
            _Damage++;
            _FreeBonus--;
            text.text = _FreeBonus.ToString();
        }
    }
    public void Minus_Damage()
    {
        if (_Damage > 0)
        {
            _damage.fillAmount -= 0.2f;
            _Damage--;
            _FreeBonus++;
            text.text = _FreeBonus.ToString();
        }
    }
}
