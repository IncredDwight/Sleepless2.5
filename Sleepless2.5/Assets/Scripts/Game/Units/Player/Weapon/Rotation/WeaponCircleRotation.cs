using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCircleRotation : MonoBehaviour
{
    [SerializeField] private Joystick _shootingJoystick;
    [SerializeField] private Transform _shootingPoint;

    private float _radius = 3;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(_shootingJoystick.GetDirection().normalized.y, _shootingJoystick.GetDirection().normalized.x);
        _shootingPoint.localPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _radius;
    }

}
