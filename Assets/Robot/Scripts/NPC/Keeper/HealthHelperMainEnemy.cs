using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHelperMainEnemy : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float DamageFromRobotSensivity = 0.1f;
    public float DamageToRobotSensivity = 0.1f;
    public GameObject Explosion;

    public float _health = 0;

    private Rigidbody _rigidbody;
    private UIHealthBarKeeper UIHealthBarKeeper;

    public int State
    {
        get => (int)((MaxHealth - _health - 0.00001) / (MaxHealth / 3));
    }

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>() as Rigidbody;
        _health = MaxHealth;
        UIHealthBarKeeper = GameObject.Find("Canvas").
            transform.Find("Keeper Health Bar").
            GetComponent<UIHealthBarKeeper>();
        UIHealthBarKeeper.MaxHealth = MaxHealth;
        UIHealthBarKeeper.Health = _health;
    }

    public void GetRobotHit(Collision collision)
    {
        float me = _rigidbody.velocity.magnitude;
        float enemy = collision.rigidbody.velocity.magnitude;
        float relVel = collision.relativeVelocity.magnitude;
        if (me < enemy)
        {
            _rigidbody.AddForce(collision.GetContact(0).normal * relVel * 0.1f, ForceMode.Impulse);
        }
        me *= me;
        enemy *= enemy;
        GetDamage(enemy / (me + enemy) * relVel * DamageFromRobotSensivity, null);
        HealthHelper enemyHealthHelper;
        if (collision.transform.parent)
            enemyHealthHelper = collision.transform.parent.GetComponent<HealthHelper>();
        else
            enemyHealthHelper = null;
        if (enemyHealthHelper)
        {
            enemyHealthHelper.GetDamage(me / (me + enemy) * relVel * DamageToRobotSensivity, null);
        } 

    }

    public void GetDamage(float damage, HealthHelper killer)
    {
        print(gameObject.name + " take damage: " + damage);
        _health -= damage;
        UIHealthBarKeeper.Health = _health;
        if (_health <= 0)
        {
            GameObject explosion = Instantiate(Explosion, _rigidbody.transform.position, Quaternion.identity);
            ParticleSystem explosionParticleSystem = explosion.GetComponent<ParticleSystem>() as ParticleSystem;
            UIHealthBarKeeper.Hide();
            Destroy(gameObject);
            Destroy(explosion, explosionParticleSystem.main.duration);
        }
    }

    private void Update()
    {
        UIHealthBarKeeper.Health = _health;
    }
}
