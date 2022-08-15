using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IHeal))]
public class HealthStealPassive : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _stealAmount;

    private IHeal _heal;

    private void Awake()
    {
        _heal = GetComponent<IHeal>();
        GameEvents.OnUnitDied += Heal;
    }

    private void Heal(float health)
    {
        _heal.Heal(health * _stealAmount);
    }

    private void OnDisable()
    {
        GameEvents.OnUnitDied -= Heal;
    }
}
