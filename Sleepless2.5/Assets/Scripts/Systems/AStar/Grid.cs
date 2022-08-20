using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Vector2 _size;
    [SerializeField] private float _nodeRadius = 1;
    [SerializeField] private float _gridDisplayOffset = 0.1f;

    private Node[,] _grid;


    private void Start()
    {
        int gridXSize = Mathf.RoundToInt(_size.x / (_nodeRadius * 2));
        int gridYSize = Mathf.RoundToInt(_size.y / (_nodeRadius * 2));
        CreateGrid(gridXSize, gridYSize);
    }

    private void CreateGrid(int xSize, int ySize)
    {
        _grid = new Node[xSize, ySize];
        Vector3 worldBottomLeft = transform.position - Vector3.right * (_size.x / 2) - Vector3.up * (_size.y / 2);

        for(int x = 0; x < xSize; x++)
            for (int y = 0; y < ySize; y++)
            {
                Vector3 worldPosition = worldBottomLeft + Vector3.right * (x * _nodeRadius * 2 + _nodeRadius) + Vector3.up * (y * _nodeRadius * 2 + _nodeRadius);
                bool isWalkable = Physics2D.OverlapCircle(worldPosition, _nodeRadius) == null;
                _grid[x, y] = new Node(isWalkable, worldPosition);
            }
    }

    private Node GetNodeFromPosition(Vector2 position)
    {
        float percentX = Mathf.Clamp01((position.x + _size.x / 2) / _size.x);
        float percentY = Mathf.Clamp01((position.y + _size.y / 2) / _size.y);

        int x = Mathf.RoundToInt((_grid.GetLength(0) - 1) * percentX);
        int y = Mathf.RoundToInt((_grid.GetLength(1) - 1) * percentY);

        return _grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, _size);
        if(_grid != null)
            foreach(Node node in _grid)
            {
                Gizmos.color = (node.IsWalkabe()) ? Color.white : Color.red;
                Gizmos.DrawCube(node.GetWorldPosition(), Vector3.one * (_nodeRadius * 2 - _gridDisplayOffset));
            }
    }
}
