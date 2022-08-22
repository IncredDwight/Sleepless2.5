using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class PathfindingAI : MonoBehaviour, IMovable
{
    [SerializeField] private Target _target;
    private Transform _currentTarget;
    [SerializeField] private float _speed = 30;
    private float _speedMultiplier = 50;
    private bool _canMove = true;

    [SerializeField] private float _nextWaypointDistance = 0.5f;

    private Path _path;
    private int _currentWaypoint;

    private Seeker _seeker;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private Vector2 _kickOffDirection;

    private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(UpdatePath), 0, .5f);
    }

    private void UpdatePath()
    {
        if(_currentTarget == null)
            _currentTarget = GameObject.FindGameObjectWithTag(_target.ToString()).transform;
        _seeker.StartPath(_rigidbody2D.position, _currentTarget.position, OnPathComplete);

    }

    private void Update()
    {
        if (_path != null)
        {
            if (_currentWaypoint >= _path.vectorPath.Count)
            {
                return;
            }

            Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rigidbody2D.position).normalized;
            Vector2 force = direction * _speed;
            if (_canMove)
                _rigidbody2D.velocity = force;

            float distance = Vector2.Distance(_rigidbody2D.position, _path.vectorPath[_currentWaypoint]);

            if (distance < _nextWaypointDistance)
                _currentWaypoint++;

        }

        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(KickOff(_kickOffDirection));
    }

    private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            _path = path;
            _currentWaypoint = 0;
        }
    }

    public IEnumerator KickOff(Vector2 direction, float power = 10, float kickOffTime = 0.5f)
    {
        _canMove = false;
        _rigidbody2D.velocity = direction * power;
        yield return new WaitForSeconds(kickOffTime);
        _canMove = true;
    }

    public void IncreaseMovementSpeed(float amount)
    {
        _speed += amount;
    }

    public void DecreaseMovementSpeed(float amount)
    {
        _speed -= amount;
        if (_speed < 0)
            _speed = 0;
    }

    public Vector2 GetMovementDirection()
    {
        if (_rigidbody2D == null)
            return Vector2.zero;
        return _rigidbody2D.velocity;
    }

    public float GetMovementSpeed()
    {
        return _speed;
    }
}