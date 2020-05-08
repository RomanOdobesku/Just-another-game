using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Improvement_Helper : MonoBehaviour
{
    public Image _speed;
    float _Speed;
    public Image _health;
    float _Health;
    public Image _damage;
    float _Damage;
    public Text text;
   // Const_and_other.count_Bonus
    //public int _free_improvement;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _speed.fillAmount = 0;
        _health.fillAmount = 0;
        _damage.fillAmount = 0;
        text.text = Const_and_other.count_Bonus.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Plus_Speed()
    {
        if (Const_and_other.count_Bonus > 0 && _Speed < 5)
        {
            _speed.fillAmount += 0.2f;
            _Speed++;
            Const_and_other.count_Bonus--;
            text.text = Const_and_other.count_Bonus.ToString();
        }  
    }
    public void Minus_Speed()
    {
        if (_Speed > 0)
        {
            _speed.fillAmount -= 0.2f;
            _Speed--;
            Const_and_other.count_Bonus++;
            text.text = Const_and_other.count_Bonus.ToString();
        }
        
    }
    public void Plus_Health()
    {
        if (Const_and_other.count_Bonus > 0 && _Health < 5)
        {
            _health.fillAmount += 0.2f;
            _Health++;
            Const_and_other.count_Bonus--;
            text.text = Const_and_other.count_Bonus.ToString();
        }
    }
    public void Minus_Health()
    {
        if (_Health > 0)
        {
            _health.fillAmount -= 0.2f;
            _Health--;
            Const_and_other.count_Bonus++;
            text.text = Const_and_other.count_Bonus.ToString();
        }
    }
    public void Plus_Damage()
    {
        if (Const_and_other.count_Bonus > 0 && _Damage < 5)
        {
            _damage.fillAmount += 0.2f;
            _Damage++;
            Const_and_other.count_Bonus--;
            text.text = Const_and_other.count_Bonus.ToString();
        }
    }
    public void Minus_Damage()
    {
        if (_Damage > 0)
        {
            _damage.fillAmount -= 0.2f;
            _Damage--;
            Const_and_other.count_Bonus++;
            text.text = Const_and_other.count_Bonus.ToString();
        }
    }
}
