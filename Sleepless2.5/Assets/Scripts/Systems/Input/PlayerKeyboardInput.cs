using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardInput : PlayerInput
{
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _abilityKey = KeyCode.C;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public override Vector2 GetMovementDirection()
    {
        return new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));
    }

    public override Vector2 GetWeaponDirection()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    public override bool GetAttackKey()
    {
        return Input.GetKey(_attackKey);
    }

    public override bool GetAbilityKey()
    {
        return Input.GetKeyDown(_abilityKey);
    }
}
