using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private TilesGenerator _tilesGenerator;
    [SerializeField] private DecorationsGenerator _decorationsGenerator;

    [SerializeField] private Vector2 _minCoordinate;
    [SerializeField] private Vector2 _maxCoordinate;

    [SerializeField] private string _prefabName = "Map";

    private void Awake()
    {
        Transform parent = new GameObject(_prefabName).transform;
        _tilesGenerator.Generate(_minCoordinate, _maxCoordinate, out Transform tilesParent);
        _decorationsGenerator.Generate(_minCoordinate, _maxCoordinate, out Transform decorationsParent);
        AstarPath.active.Scan(AstarPath.active.data.gridGraph);
        tilesParent.parent = parent;
        decorationsParent.parent = parent;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, _maxCoordinate - _minCoordinate);
    }
}
