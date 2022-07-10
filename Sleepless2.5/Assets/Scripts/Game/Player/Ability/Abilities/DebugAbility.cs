using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAbility : MonoBehaviour, IAbility
{
    public void Execute()
    {
        Debug.Log("Test ability");
    }
}
