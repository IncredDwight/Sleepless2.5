using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AStarPathfinding : Singleton<AStarPathfinding>
{
    [SerializeField] private Grid _grid;

    private void Awake()
    {
        _grid = FindObjectOfType<Grid>();
    }

    public void StartFindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        StartCoroutine(FindPath(startPosition, targetPosition));
    }

    private IEnumerator FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Vector3[] waypoints = new Vector3[0];
        bool isSucceeded = false;

        Node startNode = _grid.GetNodeFromPosition(startPosition);
        Node targetNode = _grid.GetNodeFromPosition(targetPosition);

        if (startNode.IsWalkabe() && targetNode.IsWalkabe())
        {
            Heap<Node> nodesToEvaluate = new Heap<Node>(32400);
            HashSet<Node> evaluatedNodes = new HashSet<Node>();
            nodesToEvaluate.Add(startNode);

            while (nodesToEvaluate.Count > 0)
            {
                Node currentNode = nodesToEvaluate.PullOffFirst();
                evaluatedNodes.Add(currentNode);

                if (currentNode == targetNode)
                {
                    isSucceeded = true;
                    break;
                }

                foreach (Node neighbour in _grid.GetNodeNeighbours(currentNode))
                {
                    if (!(!neighbour.IsWalkabe() || evaluatedNodes.Contains(neighbour)))
                    {
                        int newMovementCostToNeighbour = currentNode.DistanceFromStartingNode + GetDistance(currentNode, neighbour);
                        if (newMovementCostToNeighbour < neighbour.DistanceFromStartingNode || !nodesToEvaluate.Contains(neighbour))
                        {
                            neighbour.DistanceFromStartingNode = newMovementCostToNeighbour;
                            neighbour.DistanceFromEndNode = GetDistance(neighbour, targetNode);
                            neighbour.Parent = currentNode;

                            if (!nodesToEvaluate.Contains(neighbour))
                                nodesToEvaluate.Add(neighbour);
                            else
                                nodesToEvaluate.UpdateItem(neighbour);
                        }
                    }
                }

            }
        }
        yield return null;
        if (isSucceeded)
            waypoints = GetPath(startNode, targetNode);
        PathRequestManager.Instance.FinishProcessingPath(waypoints, isSucceeded);
    }

    private Vector3[] GetPath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode.Parent);
            currentNode = currentNode.Parent;
        }

        Vector3[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints);

        _grid.Path = path;

        return waypoints;
    }

    private Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 oldDirection = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 newDirection = new Vector2(path[i - 1].GetX() - path[i].GetX(), path[i - 1].GetY() - path[i].GetY());
            if (newDirection != oldDirection)
                waypoints.Add(path[i].GetWorldPosition());
            oldDirection = newDirection;
        }

        return waypoints.ToArray();
    }

    private int GetDistance(Node node1, Node node2)
    {
        int diagnalMoveCost = 14;
        int horizontalMoveCost = 10;

        int distanceX = Mathf.Abs(node1.GetX() - node2.GetX());
        int distanceY = Mathf.Abs(node1.GetY() - node2.GetY());

        return
            (distanceX > distanceY) ?
            diagnalMoveCost * distanceY + horizontalMoveCost * (distanceX - distanceY) :
            diagnalMoveCost * distanceX + horizontalMoveCost * (distanceY - distanceX);
    }
}
