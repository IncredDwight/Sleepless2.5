using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITakeDamage takeDamage = collision.gameObject.GetComponent<ITakeDamage>();
        takeDamage?.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
