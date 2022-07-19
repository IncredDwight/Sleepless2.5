using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _movementSpeed = 5;

    private Rigidbody2D _rigidbody2d;
    private Vector2 _movementDirection;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
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
        _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
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
}
