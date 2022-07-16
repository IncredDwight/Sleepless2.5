using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Totem : MonoBehaviour
{
    [SerializeField] private StatusEffectData _totemEffect;

    [SerializeField] private float _totemRadius = 1; 

    private void Update()
    {
        FindEffectable();
    }

    private void FindEffectable()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _totemRadius);
        if(colliders.Length > 1)
            ApplyEffect(_totemEffect, colliders);
    }   

    protected abstract void ApplyEffect(StatusEffectData effect, Collider2D[] target);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _totemRadius);
    }
}
