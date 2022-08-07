using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IProjectile))]
public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Target _target = Target.All;

    private IProjectile _projectile;

    private void Awake()
    {
        _projectile = GetComponent<IProjectile>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != _projectile.Sender)
        {
            if (_target != Target.All)
                if (!collision.gameObject.CompareTag(_target.ToString()))
                    return;
            ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
            takeDamage?.TakeDamage(_damage);
            PoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
