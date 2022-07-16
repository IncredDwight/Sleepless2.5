using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLossStatusEffect : StatusEffect
{
    private ITakeDamage _takeDamage;

    private void OnEnable()
    {
        _takeDamage = GetComponent<ITakeDamage>();
    }

    protected override void Affect()
    {
        _takeDamage.TakeDamage(_effectAmount);
    }
}
