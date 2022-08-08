using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour, IAttackable
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _sender;

    [SerializeField] private int _projectileAmount = 1;
    private int _projectileAngle = 10;

    public void Attack()
    {
        for (int i = 0; i < _projectileAmount; i++)
        {
            Projectile projectile = PoolManager.Instance.GetPool(_projectile).GetObject(_shootingPoint.position, _shootingPoint.rotation).GetComponent<Projectile>();
            if(_projectileAmount > 1)
                projectile.transform.Rotate(new Vector3(0, 0, (i - 1) * _projectileAngle));
            projectile.Sender = (_sender == null) ? gameObject : _sender;
        }
    }

    public void SetProjectile(GameObject projectile)
    {
        _projectile = projectile;
    }

    public void SetProjectileAmount(int amount)
    {
        _projectileAmount = amount;
    }

    public int GetProjectileAmount()
    {
        return _projectileAmount;
    }
}
