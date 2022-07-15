using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStatusEffect : StatusEffect
{
    protected override void Affect()
    {
        Debug.Log(_effectAmount);
    }
}
