using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _target;

    private Vector3 _targetPosition;

    private void Awake()
    {
        GameEvents.OnCharacterSpawned += SetTarget;
    }

    private void OnDisable()
    {
        GameEvents.OnCharacterSpawned -= SetTarget;
    }

    private void FixedUpdate()
    {
        _targetPosition = _target.position;
        _targetPosition.z = -10;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private void SetTarget(GameObject target)
    {
        _target = target.transform;
    }
}
