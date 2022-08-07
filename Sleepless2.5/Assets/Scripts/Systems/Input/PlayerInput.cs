using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public abstract Vector2 GetMovementDirection();
    public abstract Vector2 GetWeaponDirection();
    public abstract bool GetAttackKey();
    public abstract bool GetAbilityKey();
}
