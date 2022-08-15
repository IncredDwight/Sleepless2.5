using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class PathfindingAI : MonoBehaviour, IMovable
{
    private Seeker _seeker;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]private Transform _target;
    private Path _path;
    private int _currentWaypoint;
    private bool _isEndOfPathReached;
    [SerializeField] private float _speed = 30;
    [SerializeField] private float _nextWaypointDistance = 3;

    private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        

        InvokeRepeating(nameof(UpdatePath), 2, .5f);
    }

    private void UpdatePath()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _seeker.StartPath(_rigidbody2D.position, _target.position, OnPathComplete);
        
    }

    private void FixedUpdate()
    {
        if(_path != null)
        {
            if (_currentWaypoint >= _path.vectorPath.Count)
            {
                return;
            }

            Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rigidbody2D.position).normalized;
            Vector2 force = direction * _speed * Time.deltaTime;
            _rigidbody2D.velocity = force;

            float distance = Vector2.Distance(_rigidbody2D.position, _path.vectorPath[_currentWaypoint]);

            if (distance < _nextWaypointDistance)
                _currentWaypoint++;

        }
    }

    private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            _path = path;
            _currentWaypoint = 0;
        }
    }

    public void IncreaseMovementSpeed(float amount)
    {
        throw new System.NotImplementedException();
    }

    public void DecreaseMovementSpeed(float amount)
    {
        throw new System.NotImplementedException();
    }

    public Vector2 GetMovementDirection()
    {
        throw new System.NotImplementedException();
    }

    public float GetMovementSpeed()
    {
        throw new System.NotImplementedException();
    }
}
