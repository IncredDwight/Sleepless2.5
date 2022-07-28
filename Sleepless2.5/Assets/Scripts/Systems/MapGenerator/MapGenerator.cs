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
        //Bounds bounds = GetBounds(tile.transform.GetChild(0));
        Vector2 minPoint = TransformExtremums.GetMinPoint(tile.transform.GetChild(0));
        Vector2 maxPoint = TransformExtremums.GetMaxPoint(tile.transform.GetChild(0));
        tile.AddComponent<Tile>().SetBounds(minPoint, maxPoint);
        Debug.Log($"Min: {minPoint}, Max: {maxPoint}");
        Collider2D[] colliders = Physics2D.OverlapBoxAll((maxPoint + minPoint) / 2, (maxPoint - minPoint) * _space, 0);
        foreach(Collider2D collider in colliders)
            if(collider.transform.parent != tile.transform.GetChild(0))
            {
                Destroy(tile);

            }
        /*if(tile != null)
        {
            Debug.Log(TransformExtremums.GetMinPoint(tile.transform.GetChild(0)));
            Debug.Log(TransformExtremums.GetMaxPoint(tile.transform.GetChild(0)));
            Vector2 minPoint = TransformExtremums.GetMinPoint(tile.transform.GetChild(0));
            Vector2 maxPoint = TransformExtremums.GetMaxPoint(tile.transform.GetChild(0));
            tile.AddComponent<Tile>().SetBounds(maxPoint - minPoint);
        }*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, _maxCoordinate - _minCoordinate);
    }
}
