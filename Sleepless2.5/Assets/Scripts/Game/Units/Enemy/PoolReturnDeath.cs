using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturnDeath : MonoBehaviour, IDie
{
    public void Die()
    {
        PoolManager.Instance.ReturnToPool(gameObject);
    }
}
