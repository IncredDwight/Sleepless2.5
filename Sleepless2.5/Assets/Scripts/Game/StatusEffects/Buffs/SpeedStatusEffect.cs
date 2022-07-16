using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStatusEffect : StatusEffect
{
    private IMovable _movable;
    private float _defaultSpeed;

    private void OnEnable()
    {
        _movable = GetComponent<IMovable>();
        _defaultSpeed = (_movable != null) ? _movable.GetMovementSpeed() : 0;
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        _movable?.IncreaseMovementSpeed(_effectAmount * _defaultSpeed);
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        _movable?.DecreaseMovementSpeed(_effectAmount * _defaultSpeed);
    }
}
