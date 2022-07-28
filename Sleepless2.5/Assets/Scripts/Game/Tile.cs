using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2 _minPoint, _maxPoint;

    public void SetBounds(Vector2 minPoint, Vector2 maxPoint)
    {
        _minPoint = minPoint;
        _maxPoint = maxPoint;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube((_maxPoint + _minPoint)/2, (_maxPoint - _minPoint) * 1.35f);
    }
}
