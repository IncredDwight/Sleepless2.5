using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour, IPlayerAttack
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _projectile;

    public void Attack()
    {
        Vector2 direction = -transform.position + _shootingPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(_projectile, _shootingPoint.position, Quaternion.identity).transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
