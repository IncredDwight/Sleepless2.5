using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTotem : Totem
{
    protected override void ApplyEffect(StatusEffectData effect, Collider2D[] target)
    {
        for (int i = 0; i < target.Length; i++)
        {
            IEffectable effectable = target[i].GetComponent<IEffectable>();
            if (effectable.GetType() == typeof(EnemyStatusEffectHandler))
                effectable?.ApplyEffect(effect);
        }
    }
}
