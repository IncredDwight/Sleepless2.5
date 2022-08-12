using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturnDeath : MonoBehaviour, IDie
{
    [SerializeField] private GameObject _blood;
    public void Die()
    {
        PoolManager.Instance.GetPool(_blood).GetObject(transform.position, Quaternion.identity);
        PoolManager.Instance.ReturnToPool(gameObject);
    }
}
