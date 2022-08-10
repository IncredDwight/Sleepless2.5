using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class FireRateHealthPassive : MonoBehaviour
{
    [Range(0.5f, 5), SerializeField] private float _gainSpeed = 1;

    private Health _health;
    private IAttackRate _attackRate;

    private float _startAttackRate;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attackRate = GetComponentInChildren<IAttackRate>();

        _startAttackRate = _attackRate.GetAttackRate();
        _health.OnHealthChanged += UpdateAttackRate;
    }

    private void UpdateAttackRate(float amount)
    {
        if(amount != 0)
            _attackRate.SetAttackRate(_startAttackRate - (_gainSpeed / amount) * _startAttackRate);
    } 
}
