using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticPoolReturn : MonoBehaviour
{
    [SerializeField] private float _returnTime = 0;

    private void Awake()
    {
        Invoke(nameof(Return), _returnTime);
    }

    private void Return()
    {
        PoolManager.Instance.ReturnToPool(gameObject);
    }
}
