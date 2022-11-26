using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private JoyStick _joystick;
    [SerializeField] private Rigidbody2D _rb;

    private const float _MOVEMENT_SPEED = 3.0f;

    private void FixedUpdate()
    {
        if (_joystick.vec.y != 0)
            _rb.velocity = _joystick.vec * _MOVEMENT_SPEED;
        else 
            _rb.velocity = Vector2.zero;
    }
}
