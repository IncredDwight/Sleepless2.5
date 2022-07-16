using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyStatusEffectHandler : MonoBehaviour, IEffectable
{
    public void ApplyEffect(StatusEffectData data)
    {
        Type effectType = Type.GetType(data.Name);
        StatusEffect effect = (StatusEffect)gameObject.GetComponent(effectType);
        if (effect != null)
            effect.ResetEffect();
        else
        {
            StatusEffect statusEffect = (StatusEffect)gameObject.AddComponent(effectType);
            statusEffect.SetData(data);
        }
    }

    public void RemoveEffect(StatusEffectData data)
    {
        Type effectType = Type.GetType(data.Name);
        Component effect = gameObject.GetComponent(effectType);
        if(effect != null)
            Destroy(effect);
    }
}
