using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLossStatusEffect : StatusEffect
{
    private Health _health;

    private void OnEnable()
    {
        _health = GetComponent<Health>();
    }

    protected override void Affect()
    {
        _health.TakeDamage(_effectAmount * _health.GetMaxHealth());
    }
}
