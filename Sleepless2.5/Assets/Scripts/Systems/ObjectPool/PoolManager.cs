using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private Dictionary<int, Pool> _pools = new Dictionary<int, Pool>();

    private Transform _poolsParent;
    private string _poolsParentName = "[POOLS]";

    private void Awake()
    {
        _poolsParent = (GameObject.Find(_poolsParentName) ?? new GameObject(_poolsParentName)).transform;
    }

    public Pool CreatePool(GameObject prefab, int poolSize = 5)
    {
        int poolId = prefab.GetInstanceID();

        if(_pools.ContainsKey(poolId) == false)
        {
            Pool pool = new GameObject($"{prefab.name} Pool").AddComponent<Pool>();
            pool.transform.SetParent(_poolsParent);
            pool.InitializePool(prefab, poolSize);
            _pools.Add(poolId, pool);

            return pool;
        }

        return _pools[poolId];
    }

    public Pool GetPool(int id)
    {
        if (_pools.ContainsKey(id))
            return _pools[id];

        return null;
    }

}
