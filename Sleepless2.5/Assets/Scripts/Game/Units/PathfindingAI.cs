using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(AStarPathfinding))]
public class PathfindingAI : MonoBehaviour, IMovable
{
    [SerializeField] private Target _target;
    private Transform _currentTarget;
    [SerializeField] private float _speed = 30;
    private float _speedMultiplier = 50;
    private bool _canMove = true;

    [SerializeField] private float _nextWaypointDistance = 0.5f;

    private List<Node> _path;
    private int _currentWaypoint;

    private Seeker _seeker;
    private AStarPathfinding _aStarPathfinding;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private Vector2 _kickOffDirection;

    private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _aStarPathfinding = GetComponent<AStarPathfinding>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        

        InvokeRepeating(nameof(UpdatePath), 0, .5f);
    }

    private void UpdatePath()
    {
        if(_currentTarget == null)
            _currentTarget = GameObject.FindGameObjectWithTag(_target.ToString()).transform;
        _aStarPathfinding.FindPath(_rigidbody2D.position, _currentTarget.position, out _path);
        //_seeker.StartPath(_rigidbody2D.position, _currentTarget.position, OnPathComplete);
        
    }

    private void FixedUpdate()
    {
        if(_path != null)
        {
            if (_currentWaypoint >= _path.Count)
            {
                return;
            }

            Vector2 direction = ((Vector2)_path[_currentWaypoint].GetWorldPosition() - _rigidbody2D.position).normalized;
            Vector2 force = direction * _speed * _speedMultiplier * Time.deltaTime;
            if(_canMove)
                _rigidbody2D.velocity = force;

            float distance = Vector2.Distance(_rigidbody2D.position, _path[_currentWaypoint].GetWorldPosition());

            if (distance < _nextWaypointDistance)
                _currentWaypoint++;

        }

        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(KickOff(_kickOffDirection));
    }

    /*private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            _path = path;
            _currentWaypoint = 0;
        }
    }*/

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
        return _rigidbody2D.velocity;
    }

    public float GetMovementSpeed()
    {
        return _speed;
    }
}
