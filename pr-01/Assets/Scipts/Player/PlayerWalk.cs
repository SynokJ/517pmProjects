using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

    [SerializeField] private PathFinding _pathFinding;
    [SerializeField] private PlayerInput _playerInput;

    public event Action OnArrived;

    private Camera _camera;
    private Vector2 _destinationPoint;
    private List<Node> _steps = new List<Node>();
    private const float _MOVE_SPEED = 5.0f;

    private void Start()
    {
        _playerInput.OnMoved += OnMove;
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (IsPlayerReachedDestination())
            return;


        if (Vector2.Distance(_steps[0].position, transform.position) <= 0.01f)
        {
            _steps.RemoveAt(0);

            if (IsPlayerReachedDestination())
                OnArrived?.Invoke();
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, _steps[0].position, _MOVE_SPEED * Time.deltaTime);
    }

    private bool IsPlayerReachedDestination() => _steps == null || _steps.Count == 0;

    public void OnMove(Vector2 touchPos)
    {
        _destinationPoint = _camera.ScreenToWorldPoint(touchPos);
        _pathFinding.InitPath(transform.position, _destinationPoint);
        _steps = _pathFinding.GetPath();
    }
}
