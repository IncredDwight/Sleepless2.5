using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : Singleton<GameEvents>
{
    public Action<float> OnUnitDied;
    public void SendUnitDied(float health)
    {
        OnUnitDied?.Invoke(health);
    }
}
