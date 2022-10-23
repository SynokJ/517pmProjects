using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnMoved = default;

    private bool _isInTouched;
    private Touch _currentTouch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            _currentTouch = Input.GetTouch(0);

            if (_currentTouch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(_currentTouch.fingerId))
            {
                _isInTouched = true;
                OnMoved?.Invoke(_currentTouch.position);
            }
        }
        else if (_isInTouched)
            _isInTouched = false;

        if (_isInTouched)
            Debug.Log("Player is touchin the screen! => " + Time.time);
    }
}
