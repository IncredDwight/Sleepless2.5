using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IProjectile))]
public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float _damage;

    private IProjectile _projectile;

    private void Awake()
    {
        _projectile = GetComponent<IProjectile>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != _projectile.Sender)
        {
            ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
            takeDamage?.TakeDamage(_damage);
            PoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
