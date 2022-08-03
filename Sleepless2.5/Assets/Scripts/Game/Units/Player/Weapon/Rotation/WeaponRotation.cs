using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(_playerInput.GetWeaponDirection().y, _playerInput.GetWeaponDirection().x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
