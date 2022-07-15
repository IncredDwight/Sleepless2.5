using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatusEffectHandler : MonoBehaviour, IEffectable
{
    private List<StatusEffect> statusEffects = new List<StatusEffect>();

    public void ApplyEffect(StatusEffectData data)
    {
        Type effectType = Type.GetType(data.Name);
        Component effect = gameObject.GetComponent(effectType);
        if (effect != null)
        {
            RemoveEffect(data);
        }

        StatusEffect statusEffect = (StatusEffect)gameObject.AddComponent(effectType);
        statusEffect.SetData(data);
        statusEffects.Add(statusEffect);
    }

    public void RemoveEffect(StatusEffectData data)
    {
        Type effectType = Type.GetType(data.Name);
        Component effect = gameObject.GetComponent(effectType);
        if(effect != null)
        {
            statusEffects.Remove((StatusEffect)effect);
            Destroy(effect);
        }
    }
}
