using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAbility : MonoBehaviour, IAbility
{
    [SerializeField] private GameObject _turretPrefab;

    public void Execute()
    {
        PoolManager.Instance.GetPool(_turretPrefab).GetObject(transform.position, Quaternion.identity);
    }
}
