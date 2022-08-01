using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLock : MonoBehaviour, IWeaponLock
{
    [SerializeField] private Transform _shootingPoint;

    public bool IsWeaponLocked()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootingPoint.position, transform.position - _shootingPoint.position);
        Debug.Log(hit.collider.name);
        Debug.DrawLine(_shootingPoint.position, hit.point);
        return hit.collider.gameObject != transform.parent.gameObject;
    }
}
