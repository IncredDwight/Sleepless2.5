using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class TeleportAbility : MonoBehaviour, IAbility
{
    [SerializeField] private float _teleportDistance;
    [SerializeField] private float _kickOffRadius = 5;
    [SerializeField] private float _kickOffPower = 10;
    

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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _kickOffRadius);
        foreach(Collider2D collider in colliders)
        {
            PathfindingAI pathfindingAI = collider.GetComponent<PathfindingAI>();
            if(pathfindingAI != null)
                StartCoroutine(pathfindingAI.KickOff(collider.transform.position - transform.position, _kickOffPower));
        }
    }
}
