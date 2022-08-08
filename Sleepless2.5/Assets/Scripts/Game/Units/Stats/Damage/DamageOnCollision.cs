using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Target _target = Target.All;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_target != Target.All)
            if (!collision.gameObject.CompareTag(_target.ToString()))
                return;
        ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
        takeDamage?.TakeDamage(_damage);
        PoolManager.Instance.ReturnToPool(gameObject);

    }
}
