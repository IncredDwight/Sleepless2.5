using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformExtremums : MonoBehaviour
{
    public static Vector2 GetMinPoint(Transform parent)
    {
        Vector2 minPoint = new Vector2(0, 0);
        Transform[] children = parent.GetComponentsInChildren<Transform>();

        for (int i = 0; i < children.Length; i++)
        {
            Vector2 currentPoint = children[i].transform.position;
            if (minPoint.x > currentPoint.x || minPoint.y > currentPoint.y)
                minPoint = currentPoint;
        }

        return minPoint;
    }

    public static Vector2 GetMaxPoint(Transform parent)
    {
        Vector2 maxPoint = new Vector2(0, 0);
        Transform[] children = parent.GetComponentsInChildren<Transform>();

        for (int i = 0; i < children.Length; i++)
        {
            Vector2 currentPoint = children[i].transform.position;
            if (maxPoint.x < currentPoint.x || maxPoint.y < currentPoint.y)
                maxPoint = currentPoint;
        }

        return maxPoint;
    }
}
