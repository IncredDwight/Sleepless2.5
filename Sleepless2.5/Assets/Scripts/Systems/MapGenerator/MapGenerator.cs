using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tiles;

    [SerializeField] private Vector2 _minCoordinate;
    [SerializeField] private Vector2 _maxCoordinate;
    [SerializeField] private float _space = 1.5f;
    [SerializeField] private float _density = 4;

    private void Start()
    {
        for (int k = 0; k < _density; k++)
        {
            for (float x = _minCoordinate.x; x < _maxCoordinate.x; x += Random.Range(5, 40))
            {
                for (float y = _minCoordinate.y; y < _maxCoordinate.y; y += Random.Range(20, 40))
                {
                    Spawn(x, y);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            Spawn(0, 0);
        
    }

    private void Spawn(float x, float y)
    {
        Debug.Log($"Try {x} {y}");
        Vector2 spawnPosition = new Vector2(x, y);// new Vector2(Random.Range(_minCoordinate.x, _maxCoordinate.x), Random.Range(_minCoordinate.y, _maxCoordinate.y));
        GameObject tile = Instantiate(_tiles[Random.Range(0, _tiles.Length)], spawnPosition, Quaternion.identity);

        Vector2 minPoint = TransformExtremums.GetMinPoint(tile.transform.GetChild(0));
        Vector2 maxPoint = TransformExtremums.GetMaxPoint(tile.transform.GetChild(0));

        Collider2D[] colliders = Physics2D.OverlapBoxAll((maxPoint + minPoint) / 2, (maxPoint - minPoint) * _space, 0);
        foreach(Collider2D collider in colliders)
            if(collider.transform.parent != tile.transform.GetChild(0))
            {
                Destroy(tile);
            }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, _maxCoordinate - _minCoordinate);
    }
}
