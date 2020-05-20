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
   // Const_and_other.count_Bonus
    //public int _free_improvement;
    // Start is called before the first frame update
    void Start()
    {
        _Speed = Const_and_other.speed;
        _Health = Const_and_other.health;
        _Damage = Const_and_other.damage;
        _FreeBonus = Const_and_other.count_Bonus;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _speed.fillAmount = 0.2f * _Speed;
        _health.fillAmount = 0.2f * _Health;
        _damage.fillAmount = 0.2f * _Damage;
        text.text = _FreeBonus.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        Const_and_other.count_Bonus = _FreeBonus;
        Const_and_other.speed = _Speed;
        Const_and_other.health = _Health;
        Const_and_other.damage = _Damage;
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

    //временный переходы
    public void lvl2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void lvl3()
    {
        SceneManager.LoadScene("Level_3");
    }
}
