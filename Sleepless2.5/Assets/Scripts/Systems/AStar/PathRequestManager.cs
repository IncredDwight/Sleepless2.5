using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathRequestManager : Singleton<PathRequestManager>
{
    private AStarPathfinding _aStarPathfinding;

    private Queue<PathRequest> _pathRequests = new Queue<PathRequest>();
    private PathRequest _currentPathRequest;

    private bool _isProcessingPath;

    public void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> OnPathRequest)
    {
        PathRequest pathRequest = new PathRequest(pathStart, pathEnd, OnPathRequest);
        _pathRequests.Enqueue(pathRequest);
        TryProcessNextPath();
    }

    private void TryProcessNextPath()
    {
        if (!_isProcessingPath && _pathRequests.Count > 0)
        {
            _currentPathRequest = _pathRequests.Dequeue();
            _isProcessingPath = true;
            AStarPathfinding.Instance.StartFindPath(_currentPathRequest.PathStart, _currentPathRequest.PathEnd);
        }
    }

    public void FinishProcessingPath(Vector3[] path, bool success)
    {
        _currentPathRequest.OnPathRequest(path, success);
        _isProcessingPath = false;
        TryProcessNextPath();
    }

    private struct PathRequest
    {
        public Vector3 PathStart;
        public Vector3 PathEnd;
        public Action<Vector3[], bool> OnPathRequest;

        public PathRequest(Vector3 start, Vector3 end, Action<Vector3[], bool> onPathRequest)
        {
            PathStart = start;
            PathEnd = end;
            OnPathRequest = onPathRequest;
        }
    }
}
