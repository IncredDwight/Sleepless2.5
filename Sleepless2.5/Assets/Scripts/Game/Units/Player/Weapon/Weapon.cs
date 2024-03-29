using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IAttackable))]
public class Weapon : MonoBehaviour, IAttackRate
{
    [SerializeField] private float _attackRate = 0.5f;
    private float _nextAttack;

    private IAttackable _playerAttack;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerAttack = GetComponent<IAttackable>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if(_playerInput.GetAttackKey() && Time.time > _nextAttack)
        {
            _playerAttack.Attack();
            _nextAttack = Time.time + _attackRate;
        }
    }

    public void IncreaseAttackRate(float amount)
    {
        _attackRate += amount;
    }

    public void DecreaseAttackRate(float amount)
    {
        _attackRate -= amount;
        if (_attackRate < 0)
            _attackRate = 0;
    }

    public void SetAttackRate(float amount)
    {
        _attackRate = amount;
        if (_attackRate < 0)
            _attackRate = 0;
    }

    public float GetAttackRate()
    {
        return _attackRate;
    }

}
