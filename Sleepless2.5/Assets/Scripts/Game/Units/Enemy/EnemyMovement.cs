using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(AIDestinationSetter))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    private AIPath _aiPath;
    private Target _target = Target.Player;

    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _power;

    private void Start()
    {
        _aiPath = GetComponent<AIPath>();
        //GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag(_target.ToString()).transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<Rigidbody2D>().AddForce(_direction * _power, ForceMode2D.Impulse);
            Debug.Log("Impulse");
        }
    }

    public void DecreaseMovementSpeed(float amount)
    {
        _aiPath.maxSpeed += amount;
    }

    public void IncreaseMovementSpeed(float amount)
    {
        _aiPath.maxSpeed -= amount;
    }

    public float GetMovementSpeed()
    {
        return _aiPath.maxSpeed;
    }

    public Vector2 GetMovementDirection()
    {
        if (_aiPath == null)
            return Vector2.zero;
        return _aiPath.desiredVelocity;
    }
}
