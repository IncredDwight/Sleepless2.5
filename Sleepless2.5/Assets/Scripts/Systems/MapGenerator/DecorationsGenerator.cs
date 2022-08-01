using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _decorationPrefab;

    [SerializeField]
    private float _density = 15;

    public void Generate(Vector2 minCoordinate, Vector2 maxCoordinate)
    {
        for (float x = minCoordinate.x; x <= maxCoordinate.x; x += Random.Range(0, 1f) * _density)
        {
            for (float y = minCoordinate.y; y <= maxCoordinate.y; y += Random.Range(0, 1f) * _density)
            {
                GameObject decoration = Instantiate(_decorationPrefab, new Vector2(x, y), Quaternion.identity);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(decoration.transform.position, 0.1f);
                if (colliders.Length > 1)
                    Destroy(decoration);
            }
        }
    }
}
