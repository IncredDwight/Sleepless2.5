using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnStay : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _damageRate = 0.5f;

    [SerializeField] private Target _target = Target.All;

    private float _nextDamage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time > _nextDamage)
        {
            if (_target != Target.All)
                if (!collision.gameObject.CompareTag(_target.ToString()))
                    return;
            ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
            takeDamage?.TakeDamage(_damage);
            _nextDamage = Time.time + _damageRate;
        }
    }
}
