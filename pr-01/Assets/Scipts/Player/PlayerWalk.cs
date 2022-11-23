using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [Header("Walk Parametes: ")]
    [SerializeField] private PathFinding _pathFinding;

    [Header("Player Parameters: ")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerAnimation _playerAnimation;

    [Header("Dialogue Parameters: ")]
    [SerializeField] private DialogueStart _dialogueStart;
    [SerializeField] private SpeachWindow _playerSpeach;

    public event Action OnArrived;

    private Camera _camera;
    private Vector2 _destinationPoint;
    private List<Node> _steps = new List<Node>();
    private const float _MOVE_SPEED = 5.0f;

    private void Start()
    {
        _camera = Camera.main;
    }

    #region Subscription On Event
    private void OnEnable()
    {
        _playerInput.OnMoved += OnMove;
    }

    private void OnDisable()
    {
        _playerInput.OnMoved -= OnMove;
    }
    #endregion

    private void FixedUpdate()
    {
        if (IsPlayerReachedDestination())
        {
            _playerAnimation.ResetAnimations();
            return;
        }

        MoveThroughSteps();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<I_Interactable>() != null)
        {
            _steps.Clear();
            OnArrived?.Invoke();
        }
    }

    private void MoveThroughSteps()
    {
        if (CanSwitchStep())
            SetTheNextStep();
        else
            MoveToDestination();
    }

    private void MoveToDestination()
    {
        transform.position = Vector2.MoveTowards(
                    transform.position,
                    _steps[0].position,
                    _MOVE_SPEED * Time.deltaTime
                );

        if (_steps.Count > 0)
            _playerAnimation.SetAnimationByDirection(_steps[0].position - transform.position);
    }

    private void SetTheNextStep()
    {
        _steps.RemoveAt(0);

        if (IsPlayerReachedDestination())
            OnArrived?.Invoke();
    }


    public void OnMove(Vector2 touchPos)
    {
        _destinationPoint = _camera.ScreenToWorldPoint(touchPos);

        _pathFinding.InitPath(transform.position, _destinationPoint);
        _steps = _pathFinding.GetPath();

        _playerAnimation.ResetAnimations();

        if (_playerSpeach.IsPanelActive() || _dialogueStart.IsDialogueActive())
        {
            _playerSpeach.HideMessage();
            _dialogueStart.EndDialogue();
        }
    }

    private bool IsPlayerReachedDestination()
        => _steps == null || _steps.Count == 0;

    private bool CanSwitchStep()
        => Vector2.Distance(_steps[0].position, transform.position) <= 0.01f;
}
