using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    private AIPath _aiPath;

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
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

    public float GetMovementDirection()
    {
        return _aiPath.desiredVelocity.normalized.x;
    }
}
