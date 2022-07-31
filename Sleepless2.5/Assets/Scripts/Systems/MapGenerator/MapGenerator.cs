using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tilePrefabs;
    [SerializeField] private GameObject _grassPrefab;
    private List<GameObject> _tiles = new List<GameObject>();

    [SerializeField] private Vector2 _minCoordinate;
    [SerializeField] private Vector2 _maxCoordinate;
    [SerializeField] private float _space = 1.5f;
    [SerializeField] private float _borderOffset = 10;

    private void Start()
    {
        for (int i = 0; i < (_maxCoordinate.x - _minCoordinate.x); i++)
        {
            _tiles.Add(Instantiate(_tilePrefabs[Random.Range(0, _tilePrefabs.Length)], Vector2.zero, Quaternion.identity));
        }

        for (float x = _minCoordinate.x + _borderOffset; x <= _maxCoordinate.x - _borderOffset; x++)
        {
            for (float y = _minCoordinate.y + _borderOffset; y <= _maxCoordinate.y - _borderOffset; y++)
            {
                if (_tiles.Count > 0)
                    Spawn(x, y);

            }
        }

        foreach (GameObject leftTile in _tiles)
            Destroy(leftTile);
        for (float x = _minCoordinate.x + _borderOffset; x <= _maxCoordinate.x - _borderOffset; x+=Random.Range(5, 10))
        {
            for (float y = _minCoordinate.y + _borderOffset; y <= _maxCoordinate.y - _borderOffset; y+= Random.Range(5, 10))
            {
                GameObject grass = Instantiate(_grassPrefab, new Vector2(x, y), Quaternion.identity);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(grass.transform.position, 0.1f);
                if (colliders.Length > 1)
                    Destroy(grass);
            }
        }

    }

    private void Spawn(float x, float y)
    {
        Vector2 spawnPosition = new Vector2(x, y);

        GameObject tile = _tiles[_tiles.Count - 1];
        tile.transform.position = spawnPosition;
        Transform blocks = tile.transform.GetChild(0);

        Vector2 minPoint = TransformExtremums.GetMinPoint(blocks);
        Vector2 maxPoint = TransformExtremums.GetMaxPoint(blocks);

        Physics2D.SyncTransforms();
        Collider2D[] colliders = Physics2D.OverlapBoxAll((maxPoint + minPoint) / 2, (maxPoint - minPoint) * _space, 0);

        foreach(Collider2D collider in colliders)
            if(collider.transform.parent != blocks)
            {
                return;
            }
        _tiles.RemoveAt(_tiles.Count - 1);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(transform.position, _maxCoordinate - _minCoordinate);
    }
}
