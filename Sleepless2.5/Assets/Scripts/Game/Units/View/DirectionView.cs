using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(IMovable))]
public class DirectionView : MonoBehaviour
{
    private IMovable _movement;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _movement = GetComponent<IMovable>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.flipX = _movement.GetMovementDirection() < 0;
    }
}
