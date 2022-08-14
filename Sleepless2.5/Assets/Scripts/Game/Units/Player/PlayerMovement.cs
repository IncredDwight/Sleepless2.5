using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _movementSpeed = 5;

    private Rigidbody2D _rigidbody2d;
    private PlayerInput _playerInput;
    private Vector2 _movementDirection;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        _movementDirection = _playerInput.GetMovementDirection();
    }

    private void Move()
    {
        _rigidbody2d.velocity = _movementDirection * _movementSpeed;
    }

    public void IncreaseMovementSpeed(float amount)
    {
        _movementSpeed += amount;
    }

    public void DecreaseMovementSpeed(float amount)
    {
        _movementSpeed -= amount;
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }

    public Vector2 GetMovementDirection()
    {
        return _rigidbody2d.velocity.normalized;
    }
}
