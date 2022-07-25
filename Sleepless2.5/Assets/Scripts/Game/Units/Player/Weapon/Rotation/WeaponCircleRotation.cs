using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCircleRotation : MonoBehaviour
{
    [SerializeField] private Joystick _shootingJoystick;
    [SerializeField] private Transform _shootingPoint;

    [SerializeField] private float _minRadius = 3;
    [SerializeField] private float _radiusExtendAmount = 1;
    private float _radius;

    private float _defaultAngle = Mathf.PI / 2;
    private float _inputAngle;

    private void Update()
    {
        GetInput();
        Rotate((_shootingJoystick.GetDirection() != Vector2.zero) ? _inputAngle : _defaultAngle);
    }

    private void Rotate(float angle)
    {
        _shootingPoint.localPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _radius;
        _shootingPoint.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }

    private void GetInput()
    {
        _inputAngle = Mathf.Atan2(_shootingJoystick.GetDirection().normalized.y, _shootingJoystick.GetDirection().normalized.x);
        _radius = _minRadius + _shootingJoystick.GetDirection().magnitude * _radiusExtendAmount;
    }

}
