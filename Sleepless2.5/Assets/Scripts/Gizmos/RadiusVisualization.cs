using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IRadiusVisualize))]
[ExecuteAlways]
public class RadiusVisualization : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;

    private IRadiusVisualize _radiusVisualize;

    private void Awake()
    {
        _radiusVisualize = GetComponent<IRadiusVisualize>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(_radiusVisualize.GetCenter(), _radiusVisualize.GetRadius());
    }
}
