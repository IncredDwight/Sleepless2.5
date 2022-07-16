using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPlayerAttack))]
public class Weapon : MonoBehaviour, IAttackable
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

    public void IncreaseAttackRate(float amount)
    {
        _attackRate += amount;
        Debug.Log(+amount);
    }

    public void DecreaseAttackRate(float amount)
    {
        _attackRate -= amount;
        Debug.Log(-amount);
        if (_attackRate < 0)
            _attackRate = 0;
    }

    public float GetAttackRate()
    {
        return _attackRate;
    }

}
