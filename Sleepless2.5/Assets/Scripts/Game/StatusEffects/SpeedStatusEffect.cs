using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStatusEffect : StatusEffect
{
    private IMovable _movable;

    private void OnEnable()
    {
        _movable = GetComponent<IMovable>();
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        _movable?.IncreaseMovementSpeed(_effectAmount);
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        _movable?.DecreaseMovementSpeed(_effectAmount);
    }
}
