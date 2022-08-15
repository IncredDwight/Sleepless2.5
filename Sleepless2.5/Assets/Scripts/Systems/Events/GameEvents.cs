using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    public static Action<float> OnUnitDied;
    public static void SendUnitDied(float health)
    {
        OnUnitDied?.Invoke(health);
    }

    public static Action<GameObject> OnCharacterSpawned;
    public static void SendCharacterSpawned(GameObject prefab)
    {
        OnCharacterSpawned?.Invoke(prefab);
    }
}
