using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tiles;

    [SerializeField] private Vector2 _minCoordinate;
    [SerializeField] private Vector2 _maxCoordinate;
    [SerializeField] private float _space = 1.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            Spawn();
        
    }

    private void Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_minCoordinate.x, _maxCoordinate.x), Random.Range(_minCoordinate.y, _maxCoordinate.y));
        GameObject tile = Instantiate(_tiles[Random.Range(0, _tiles.Length)], spawnPosition, Quaternion.identity);
        Bounds bounds = GetBounds(tile.transform);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(tile.transform.position, bounds.size * _space, 0);
        foreach(Collider2D collider in colliders)
            if(collider.transform.parent != tile.transform)
            {
                Destroy(tile);

            }    
    }

    private Bounds GetBounds(Transform tile)
    {
        Bounds bounds = new Bounds();
        foreach(Transform child in tile)
        {
            bounds.Encapsulate(child.GetComponent<Collider2D>().bounds);
        }

        return bounds;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, _maxCoordinate - _minCoordinate);
    }
}
