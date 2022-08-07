using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class DirectionView : MonoBehaviour
{
    private IMovable _movement;
    [SerializeField]private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _movement = GetComponent<IMovable>();
    }

    private void Update()
    {
        _spriteRenderer.flipX = _movement.GetMovementDirection() < 0;
    }
}
