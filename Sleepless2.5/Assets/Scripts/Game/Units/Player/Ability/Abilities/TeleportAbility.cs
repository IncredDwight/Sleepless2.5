using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class TeleportAbility : MonoBehaviour, IAbility
{
    [SerializeField] private float _teleportDistance;

    private IMovable _movement;
    private int _stopLayer = 8;

    private void Awake()
    {
        _movement = GetComponent<IMovable>();
    }

    public void Execute()
    {
        RaycastHit2D[] raycastHits2D = Physics2D.RaycastAll(transform.position, _movement.GetMovementDirection(), _teleportDistance);

        foreach (RaycastHit2D raycastHit2D in raycastHits2D)
        {
            if (raycastHit2D.collider.gameObject.layer == _stopLayer)
                return;
        }

        transform.position = transform.position + (Vector3)_movement.GetMovementDirection() * _teleportDistance;
    }
}
