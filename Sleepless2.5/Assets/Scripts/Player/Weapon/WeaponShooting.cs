using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour, IPlayerAttack
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private GameObject _projectile;

    public void Attack()
    {
        
    }
}
