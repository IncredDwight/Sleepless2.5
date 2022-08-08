using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturnOnHit : MonoBehaviour
{
    private int _obstacleLayer = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _obstacleLayer)
            PoolManager.Instance.ReturnToPool(gameObject);
    }
}
