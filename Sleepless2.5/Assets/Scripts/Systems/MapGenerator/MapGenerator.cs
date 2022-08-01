using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private TilesGenerator _tilesGenerator;
    [SerializeField] private DecorationsGenerator _decorationsGenerator;

    [SerializeField] private Vector2 _minCoordinate;
    [SerializeField] private Vector2 _maxCoordinate;

    private void Awake()
    {
        _tilesGenerator.Generate(_minCoordinate, _maxCoordinate);
        _decorationsGenerator.Generate(_minCoordinate, _maxCoordinate);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, _maxCoordinate - _minCoordinate);
    }
}
