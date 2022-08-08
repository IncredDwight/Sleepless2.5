using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatusEffectHandler))]
public class StatusEffectsUltimate : MonoBehaviour, IUltimate
{
    [SerializeField] private StatusEffectData[] _statusEffects;

    private PlayerStatusEffectHandler _playerStatusEffectHandler;

    private void Awake()
    {
        _playerStatusEffectHandler = GetComponent<PlayerStatusEffectHandler>();
    }

    public void Execute()
    {
        foreach (StatusEffectData statusEffectData in _statusEffects)
            _playerStatusEffectHandler.ApplyEffect(statusEffectData);
    }
}
