using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private Dictionary<GameObject, Pool> _pools = new Dictionary<GameObject, Pool>();

    private Transform _poolsParent;
    private string _poolsParentName = "[POOLS]";

    private void Awake()
    {
        _poolsParent = (GameObject.Find(_poolsParentName) ?? new GameObject(_poolsParentName)).transform;
    }

    public Pool CreatePool(GameObject prefab, int poolSize = 5)
    {
        if(_pools.ContainsKey(prefab) == false)
        {
            Pool pool = new GameObject($"{prefab.name} Pool").AddComponent<Pool>();
            pool.transform.SetParent(_poolsParent);
            pool.InitializePool(prefab, poolSize);
            _pools.Add(prefab, pool);

            return pool;
        }

        return _pools[prefab];
    }

    public void ReturnToPool(GameObject obj)
    {
        Pool pool = obj.transform.parent?.GetComponent<Pool>();
        if(pool != null)
        {
            pool.AddObject(obj);
        }
    }

    public Pool GetPool(GameObject prefab)
    {
        if (_pools.ContainsKey(prefab))
            return _pools[prefab];

        else
            return CreatePool(prefab);
    }

}
