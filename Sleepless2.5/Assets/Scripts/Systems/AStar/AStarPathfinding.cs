using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding : MonoBehaviour
{
    [SerializeField] private Grid _grid;

    [SerializeField] private Transform _seeker;
    [SerializeField] private Transform _target;

    private void Update()
    {
        FindPath(_seeker.position, _target.position);
    }

    private void FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Node startNode = _grid.GetNodeFromPosition(startPosition);
        Node targetNode = _grid.GetNodeFromPosition(targetPosition);

        List<Node> nodesToEvaluate = new List<Node>();
        HashSet<Node> evaluatedNodes = new HashSet<Node>();
        nodesToEvaluate.Add(startNode);

        while(nodesToEvaluate.Count > 0)
        {
            Node currentNode = nodesToEvaluate[0];
            for (int i = 1; i < nodesToEvaluate.Count; i++)
            {
                if (nodesToEvaluate[i].Cost < currentNode.Cost)
                    currentNode = nodesToEvaluate[i];
            }

            nodesToEvaluate.Remove(currentNode);
            evaluatedNodes.Add(currentNode);

            if (currentNode == targetNode)
            {
                GetPath(startNode, targetNode);
                return;
            }

            foreach(Node neighbour in _grid.GetNodeNeighbours(currentNode))
            {
                if(!(!neighbour.IsWalkabe() || evaluatedNodes.Contains(neighbour)))
                {
                    int newMovementCostToNeighbour = currentNode.DistanceFromStartingNode + GetDistance(currentNode, neighbour);
                    if(newMovementCostToNeighbour < neighbour.DistanceFromStartingNode || !nodesToEvaluate.Contains(neighbour))
                    {
                        neighbour.DistanceFromStartingNode = newMovementCostToNeighbour;
                        neighbour.DistanceFromEndNode = GetDistance(neighbour, targetNode);
                        neighbour.Parent = currentNode;

                        if (!nodesToEvaluate.Contains(neighbour))
                            nodesToEvaluate.Add(neighbour);
                    }
                }
            }

        }
    }

    private List<Node> GetPath(Node startNode, Node endNode)
    {
        Debug.Log("Path");
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode.Parent);
            currentNode = currentNode.Parent;
        }

        path.Reverse();

        _grid.Path = path;

        return path;
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
