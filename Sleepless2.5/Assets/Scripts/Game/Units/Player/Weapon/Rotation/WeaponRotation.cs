using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Joystick _shootingJoystick;


    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(_shootingJoystick.GetDirection().y, _shootingJoystick.GetDirection().x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
