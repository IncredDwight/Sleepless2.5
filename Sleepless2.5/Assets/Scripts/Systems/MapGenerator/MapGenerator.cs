using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tiles;

    [SerializeField] private Vector2 _minCoordinate;
    [SerializeField] private Vector2 _maxCoordinate;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            Spawn();
        
    }

    private void Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_minCoordinate.x, _maxCoordinate.x), Random.Range(_minCoordinate.y, _maxCoordinate.y));
        GameObject tile = Instantiate(_tiles[Random.Range(0, _tiles.Length)], spawnPosition, Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(tile.transform.position, new Vector2(5, 5), 0);
        foreach(Collider2D collider in colliders)
            if(collider.transform.parent != tile.transform)
            {
                Destroy(tile);
                
                //Spawn();
            }    
    }
}
