using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : PlayerInput
{
    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _weaponJoystick;

    public override bool GetAttackKey()
    {
        return _weaponJoystick.GetDirection() != Vector2.zero;
    }

    public override Vector2 GetMovementDirection()
    {
        return _movementJoystick.GetDirection();
    }

    public override Vector2 GetWeaponDirection()
    {
        return _weaponJoystick.GetDirection();
    }
}
