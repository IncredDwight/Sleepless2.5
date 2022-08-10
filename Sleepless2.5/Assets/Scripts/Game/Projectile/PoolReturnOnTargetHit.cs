using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturnOnTargetHit : MonoBehaviour
{
    [SerializeField] private Target _target = Target.Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_target != Target.All)
            if (!collision.gameObject.CompareTag(_target.ToString()))
                return;
        PoolManager.Instance.ReturnToPool(gameObject);
    }
}
