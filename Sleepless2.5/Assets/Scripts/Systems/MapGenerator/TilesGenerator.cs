using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tilePrefabs;
    private List<GameObject> _tiles = new List<GameObject>();

    [SerializeField] private float _space;

    [SerializeField] private string _parentName = "Tiles";

    public void Generate(Vector2 minCoordinate, Vector2 maxCoordinate, out Transform transform)
    {
        Transform parent = new GameObject(_parentName).transform;
        transform = parent;

        for (int i = 0; i < (maxCoordinate.x - minCoordinate.x); i++)
        {
            GameObject tile = Instantiate(_tilePrefabs[Random.Range(0, _tilePrefabs.Length)], new Vector2(0, 500), Quaternion.identity);
            _tiles.Add(tile);
            tile.transform.parent = parent;

        }

        for (float x = minCoordinate.x; x <= maxCoordinate.x; x++)
        {
            for (float y = minCoordinate.y; y <= maxCoordinate.y; y++)
            {
                if (_tiles.Count > 0)
                    SetCurrentTilePosition(x, y);

            }
        }

        foreach (GameObject leftTile in _tiles)
            Destroy(leftTile);
    }

    private void SetCurrentTilePosition(float x, float y)
    {
        Vector2 spawnPosition = new Vector2(x, y);

        GameObject tile = _tiles[_tiles.Count - 1];
        tile.transform.position = spawnPosition;
        Transform blocks = tile.transform.GetChild(0);

        Vector2 minPoint = TransformExtremums.GetMinPoint(blocks);
        Vector2 maxPoint = TransformExtremums.GetMaxPoint(blocks);

        Physics2D.SyncTransforms();
        Collider2D[] colliders = Physics2D.OverlapBoxAll((maxPoint + minPoint) / 2, (maxPoint - minPoint) * _space, 0);

        foreach (Collider2D collider in colliders)
            if (collider.transform.parent != blocks)
            {
                return;
            }
        _tiles.RemoveAt(_tiles.Count - 1);
    }
}