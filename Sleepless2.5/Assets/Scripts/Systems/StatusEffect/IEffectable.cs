using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectable
{
    void ApplyEffect(StatusEffectData data);
    void RemoveEffect(StatusEffectData data);
}
