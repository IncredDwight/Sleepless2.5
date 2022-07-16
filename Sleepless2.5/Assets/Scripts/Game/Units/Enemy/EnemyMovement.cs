using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    private AIPath _aiPath;

    public void DecreaseMovementSpeed(float amount)
    {
        _aiPath.maxSpeed += amount;
    }

    public void IncreaseMovementSpeed(float amount)
    {
        _aiPath.maxSpeed -= amount;
    }
}
