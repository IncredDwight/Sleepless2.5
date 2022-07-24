using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Joystick _shootingJoystick;

    private float _radius = 3;
    private Vector2 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }


    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(_shootingJoystick.GetDirection().normalized.y, _shootingJoystick.GetDirection().normalized.x);
        transform.localPosition = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)) * _radius;
    }


}
