using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _repeatRate;

    private Pool _pool;

    private void Awake()
    {
        _pool = PoolManager.Instance.CreatePool(_prefab);
        InvokeRepeating(nameof(Spawn), 0, _repeatRate);
    }

    private void Spawn()
    {
        _pool.GetObject(transform.position, Quaternion.identity);
    }
}
