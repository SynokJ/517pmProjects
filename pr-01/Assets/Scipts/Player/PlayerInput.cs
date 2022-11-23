using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMoved = default;

    private bool _isInTouched;
    private Touch _currentTouch;

    private I_Interactable _interactable;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            _currentTouch = Input.GetTouch(0);
            MoveToDestination();
        }
        else if (_isInTouched)
            _isInTouched = false;
    }

    /// Check for correct touch
    private bool IsTouchedForMove()
        => _currentTouch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(_currentTouch.fingerId);

    /// Try to move
    private void MoveToDestination()
    {
        if (!IsTouchedForMove())
            return;

        _isInTouched = true;
        _interactable = null;

        OnMoved?.Invoke(_currentTouch.position);
    }
}
