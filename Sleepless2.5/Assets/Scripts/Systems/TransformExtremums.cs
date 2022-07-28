using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformExtremums : MonoBehaviour
{
    public static Vector2 GetMinPoint(Transform parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Vector2 minPoint = children[0].position;

        for (int i = 0; i < children.Length; i++)
        {
            Vector2 currentPoint = children[i].transform.position;
            if (minPoint.x > currentPoint.x)
                minPoint.x = currentPoint.x;
            if (minPoint.y > currentPoint.y)
                minPoint.y = currentPoint.y;
        }

        return minPoint;
    }

    public static Vector2 GetMaxPoint(Transform parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Vector2 maxPoint = children[0].position;

        for (int i = 0; i < children.Length; i++)
        {
            Vector2 currentPoint = children[i].transform.position;
            if (maxPoint.x < currentPoint.x)
                maxPoint.x = currentPoint.x;
            if (maxPoint.y < currentPoint.y)
                maxPoint.y = currentPoint.y;
        }

        return maxPoint;
    }
}
