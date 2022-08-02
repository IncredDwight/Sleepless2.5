using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRateStatusEffect : StatusEffect
{
    private IAttackRate _attackable;
    private float _defaultRate;

    private void OnEnable()
    {
        _attackable = GetComponent<IAttackRate>();
        if (_attackable == null)
            _attackable = GetComponentInChildren<IAttackRate>();

        _defaultRate = (_attackable != null) ? _attackable.GetAttackRate() : 0;
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        _attackable?.IncreaseAttackRate(_effectAmount * _defaultRate);
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        _attackable?.DecreaseAttackRate(_effectAmount * _defaultRate);
    }
}
