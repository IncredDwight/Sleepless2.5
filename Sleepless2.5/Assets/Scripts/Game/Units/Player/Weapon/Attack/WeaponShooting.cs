using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour, IAttackable
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _sender;

    private Pool _projectilesPool;

    private void Awake()
    {
        _projectilesPool = PoolManager.Instance.CreatePool(_projectile);
    }

    public void Attack()
    {
        Projectile projectile = _projectilesPool.GetObject(_shootingPoint.position, _shootingPoint.rotation).GetComponent<Projectile>();
        projectile.Sender = (_sender == null) ? gameObject : _sender;
        projectile.Pool = _projectilesPool;
    }
}
