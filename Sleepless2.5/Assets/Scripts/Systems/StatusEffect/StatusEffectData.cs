using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Status Effect Data", menuName = "ScriptableObjects/StatusEffectData", order = 1)]
public class StatusEffectData : ScriptableObject
{
    public string Name;

    public float EffectAmount;
    public float EffectRate;
    public float LifeTime;

    public GameObject Prefab;
}
