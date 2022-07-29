using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IRadiusVisualize))]
public class RadiusVisualization : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;

    private IRadiusVisualize _radiusVisualize;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(_radiusVisualize.GetCenter(), _radiusVisualize.GetRadius());
    }
}
