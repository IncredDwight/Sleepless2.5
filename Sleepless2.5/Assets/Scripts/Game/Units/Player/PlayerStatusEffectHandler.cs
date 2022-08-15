using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStatusEffectHandler : MonoBehaviour, IEffectable
{
    public delegate void EffectApplied(StatusEffectData effect);
    public event EffectApplied OnEffectApplied;

    public delegate void EffectRemoved(StatusEffectData effect);
    public event EffectRemoved OnEffectRemoved;

    public void ApplyEffect(StatusEffectData data)
    {
        Type effectType = Type.GetType(data.Name);
        StatusEffect effect = (StatusEffect)gameObject.GetComponent(effectType);
        if (effect != null)
            effect.ResetEffect();
        else
        {
            StatusEffect statusEffect = (StatusEffect)gameObject.AddComponent(effectType);
            OnEffectApplied?.Invoke(data);
            statusEffect.SetData(data);
        }
    }

    public void RemoveEffect(StatusEffectData data)
    {
        Type effectType = Type.GetType(data.Name);
        Component effect = gameObject.GetComponent(effectType);
        if (effect != null)
        {
            OnEffectRemoved?.Invoke(data);
            Destroy(effect);
        }
    }
}
