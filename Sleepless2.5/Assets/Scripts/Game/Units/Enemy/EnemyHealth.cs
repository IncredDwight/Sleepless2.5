using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject _blood;

    protected override void Die()
    {
        PoolManager.Instance.GetPool(_blood).GetObject(transform.position, Quaternion.identity);
        PoolManager.Instance.ReturnToPool(gameObject);
    }
}
