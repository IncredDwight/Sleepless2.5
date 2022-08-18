using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private bool _isWalkable;
    private Vector3 _worldPosition;

    public Node(bool isWalkable, Vector3 worldPosition)
    {
        _isWalkable = isWalkable;
        _worldPosition = worldPosition;
    }

    public Vector3 GetWorldPosition()
    {
        return _worldPosition;
    }

    public bool IsWalkabe()
    {
        return _isWalkable;
    }
}
