using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPlayerAttack))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKey = KeyCode.K;
    [SerializeField] private float _attackRate = 0.5f;
    private float _nextAttack;

    private IPlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack = GetComponent<IPlayerAttack>();
    }

    private void Update()
    {
        if(Input.GetKey(_attackKey) && Time.time > _nextAttack)
        {
            _playerAttack.Attack();
            _nextAttack = Time.time + _attackRate;
        }
    }
}
