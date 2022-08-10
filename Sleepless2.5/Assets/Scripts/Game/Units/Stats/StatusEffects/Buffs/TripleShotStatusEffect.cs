using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotStatusEffect : StatusEffect
{
    private WeaponShooting _weaponShooting;
    private GameObject _defaultProjectile;

    private void Awake()
    {
        _weaponShooting = GetComponentInChildren<WeaponShooting>();
        _defaultProjectile = _weaponShooting.GetProjectile();
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        _weaponShooting.SetProjectileAmount((int)(_weaponShooting.GetProjectileAmount() * _effectAmount));
        if(_data.Prefab)
        _weaponShooting.SetProjectile(_data.Prefab);
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        _weaponShooting.SetProjectileAmount(1);
        _weaponShooting.SetProjectile(_defaultProjectile);
    }

}
