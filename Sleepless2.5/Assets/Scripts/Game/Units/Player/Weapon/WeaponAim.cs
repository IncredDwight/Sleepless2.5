using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WeaponAim : MonoBehaviour
{
    [SerializeField] private Transform _aimPoint;

    private LineRenderer _lineRenderer;
    private PlayerInput _input;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _input = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if (_input.GetWeaponDirection() != Vector2.zero)
        {
            _lineRenderer.enabled = true;
            RaycastHit2D hit = Physics2D.Raycast(_aimPoint.position, _aimPoint.right);
            if (hit.collider != null)
            {
                _lineRenderer.SetPosition(0, _aimPoint.position);
                _lineRenderer.SetPosition(1, hit.point);

            }
        }
        else
            _lineRenderer.enabled = false;
    }
}
