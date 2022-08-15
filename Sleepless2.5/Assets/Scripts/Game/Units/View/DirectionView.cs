using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class DirectionView : MonoBehaviour
{
    private IMovable _movement;
    [SerializeField]private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _movement = GetComponent<IMovable>();
    }

    private void Update()
    {
        if (_movement.GetMovementDirection().x > 0)
            _spriteRenderer.flipX = false;
        else if (_movement.GetMovementDirection().x < 0)
            _spriteRenderer.flipX = true;
    }
}
