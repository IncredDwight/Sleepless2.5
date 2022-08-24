using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbility : MonoBehaviour, IAbility
{
    [SerializeField] private GameObject _turretPrefab;

    public void Execute()
    {
        PoolManager.Instance.GetPool(_turretPrefab).GetObject(transform.position, Quaternion.identity);
    }
}
