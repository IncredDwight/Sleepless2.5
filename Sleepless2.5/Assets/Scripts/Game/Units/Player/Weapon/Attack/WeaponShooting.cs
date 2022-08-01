using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour, IAttackable
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _projectile;

    public void Attack()
    {
        IProjectile projectile = Instantiate(_projectile, _shootingPoint.position, _shootingPoint.rotation).GetComponent<IProjectile>();
        projectile.Sender = gameObject;
    }
}
