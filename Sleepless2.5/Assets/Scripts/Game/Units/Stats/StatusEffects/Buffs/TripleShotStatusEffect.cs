using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotStatusEffect : StatusEffect
{
    private WeaponShooting _weaponShooting;

    private void Awake()
    {
        _weaponShooting = GetComponentInChildren<WeaponShooting>();
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        _weaponShooting.SetProjectileAmount((int)(_weaponShooting.GetProjectileAmount() * _effectAmount));
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        _weaponShooting.SetProjectileAmount(1);
    }

}
