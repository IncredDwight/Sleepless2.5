using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : MonoBehaviour, IPlayerAttack
{
    [SerializeField] private float _hitRadius = 1;
    [SerializeField] private float _damage = 5;

    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _hitRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            ITakeDamage takeDamage = colliders[i].GetComponent<ITakeDamage>();
            takeDamage?.TakeDamage(_damage);
        }
    }
}