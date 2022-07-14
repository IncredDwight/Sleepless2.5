using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnStay : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _damageRate = 0.5f;
    private float _nextDamage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time > _nextDamage)
        {
            ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
            takeDamage?.TakeDamage(_damage);
            _nextDamage = Time.time + _damageRate;
        }
    }
}
