using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Totem : MonoBehaviour
{
    [SerializeField] private StatusEffectData _totemEffect;

    [SerializeField] private float _totemEffectRate = 10;
    private float _nextTotemEffect;
    [SerializeField] private float _totemRadius = 1; 

    private void Update()
    {
        if (Time.time > _nextTotemEffect)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _totemRadius);
            ApplyEffect(_totemEffect);
            _nextTotemEffect = _totemEffectRate + Time.time;
        }
    }

    protected abstract void ApplyEffect(StatusEffectData effect, Collider2D[] target);

    /*private void ApplyEffect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _totemRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            IEffectable effectable = colliders[i].GetComponent<IEffectable>();
            effectable?.ApplyEffect(_totemEffect);
        }
    }*/
}
