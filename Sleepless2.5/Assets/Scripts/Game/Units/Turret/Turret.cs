using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponShooting))]
public class Turret : MonoBehaviour, IRadiusVisualize
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Target _target = Target.Enemy;
    
    [SerializeField] private float _radius;
    [SerializeField] private float _fireRate;
    private float _nextFire;

    private GameObject _currentTarget;
    private WeaponShooting _shooting;

    private float _rotationSpeed = 20;

    private void Awake()
    {
        _shooting = GetComponent<WeaponShooting>();
    }

    private void Update()
    {
        if (_currentTarget == null)
            _currentTarget = GetTarget();
        else if (_currentTarget.activeInHierarchy && IsInSight(_currentTarget))
        {
            Aim(_currentTarget.transform.position);

            if (Time.time > _nextFire)
            {
                _shooting.Attack();
                _nextFire = Time.time + _fireRate;
            }
        }
        else
            _currentTarget = null;
    }

    private void Aim(Vector3 target)
    {
        Vector2 direction = target - _shootPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _shootPoint.rotation = Quaternion.Lerp(_shootPoint.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * _rotationSpeed);
    }

    private bool IsInSight(GameObject target)
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, target.transform.position - _shootPoint.position);
        return hit.collider.gameObject == target;
    }

    private GameObject GetTarget()
    {
        Queue<Transform> targets = new Queue<Transform>();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_shootPoint.position, _radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag(_target.ToString()))
               targets.Enqueue(colliders[i].transform);
        }

        return (targets.Count > 0) ? targets.Dequeue().gameObject : null;
    }

    public float GetRadius()
    {
        return _radius;
    }

    public Vector2 GetCenter()
    {
        return _shootPoint.position;
    }
}
