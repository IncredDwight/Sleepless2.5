using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    private bool _isWalkable;
    private Vector3 _worldPosition;
    private int _gridX;
    private int _gridY;

    public int DistanceFromStartingNode;
    public int DistanceFromEndNode;
    public Node Parent;
    public int HeapIndex { get; set; }

    public int Cost
    {
        get { return DistanceFromStartingNode + DistanceFromEndNode; }
    }


    public Node(bool isWalkable, Vector3 worldPosition, int gridX, int gridY)
    {
        _isWalkable = isWalkable;
        _worldPosition = worldPosition;
        _gridX = gridX;
        _gridY = gridY;
    }

    public Vector3 GetWorldPosition()
    {
        return _worldPosition;
    }

    public bool IsWalkabe()
    {
        return _isWalkable;
    }

    public int GetX()
    {
        return _gridX;
    }

    public int GetY()
    {
        return _gridY;
    }

    public int CompareTo(Node node)
    {
        int compare = Cost.CompareTo(node.Cost); 
        return -compare;
    }
}
