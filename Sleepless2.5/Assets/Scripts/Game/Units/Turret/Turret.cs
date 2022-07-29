using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponShooting))]
public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _radius;
    [SerializeField] private float _fireRate;
    private float _nextFire;

    private Transform[] _targets;
    private WeaponShooting _shooting;

    private void Awake()
    {
        _shooting = GetComponent<WeaponShooting>();
    }

    private void Update()
    {
        _targets = GetTargets();

        if (_targets.Length > 0)
        {
            Aim(_targets[0].position);

            if (Time.time > _nextFire)
            {
                _shooting.Attack();
                _nextFire = Time.time + _fireRate;
            }
        }
    }

    private void Aim(Vector3 target)
    {
        Vector2 direction = target - _shootPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _shootPoint.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private Transform[] GetTargets()
    {
        List<Transform> targets = new List<Transform>();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_shootPoint.position, _radius);
        List<Transform> checkingTargets = new List<Transform>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<IMovable>() != null)
                checkingTargets.Add(colliders[i].transform);
        }
        for (int i = 0; i < checkingTargets.Count; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, checkingTargets[i].transform.position - _shootPoint.position);
            if (hit.collider.gameObject == checkingTargets[i].gameObject)
                targets.Add(hit.collider.transform);
        }

        return targets.ToArray();
    }

}
