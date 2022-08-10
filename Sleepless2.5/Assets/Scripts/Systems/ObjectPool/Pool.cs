using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Queue<GameObject> _objects = new Queue<GameObject>();
    private GameObject _prefab;

    public void InitializePool(GameObject prefab, int size)
    {
        _prefab = prefab;
        GrowPool(size);
    }

    public void AddObject(GameObject obj)
    {
        if (!_objects.Contains(obj))
        {
            _objects.Enqueue(obj);
            obj.SetActive(false);
            obj.transform.localPosition = Vector3.zero;
        }
    }

    private void GrowPool(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(_prefab, transform);
            AddObject(obj);
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        if (_objects.Count <= 0)
            GrowPool();
        GameObject returningObject = _objects.Dequeue();
        returningObject.transform.position = position;
        returningObject.transform.rotation = rotation;
        returningObject.SetActive(true);
        return returningObject;
    }

}
