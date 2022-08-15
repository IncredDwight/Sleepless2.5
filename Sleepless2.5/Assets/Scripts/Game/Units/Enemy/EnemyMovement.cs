using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(AIDestinationSetter))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    private AIPath _aiPath;
    private Target _target = Target.Player;

    private void Start()
    {
        _aiPath = GetComponent<AIPath>();
        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag(_target.ToString()).transform;
    }

    public void DecreaseMovementSpeed(float amount)
    {
        _aiPath.maxSpeed += amount;
    }

    public void IncreaseMovementSpeed(float amount)
    {
        _aiPath.maxSpeed -= amount;
    }

    public float GetMovementSpeed()
    {
        return _aiPath.maxSpeed;
    }

    public Vector2 GetMovementDirection()
    {
        if (_aiPath == null)
            return Vector2.zero;
        return _aiPath.desiredVelocity;
    }
}
