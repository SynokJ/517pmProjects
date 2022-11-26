using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private JoyStick _joystick;

    public void InitMovement(Vector2 pos) => _joystick?.ShowJoystick(pos);
    public void OnMove(Vector2 pos) => _joystick.MoveJoystick(pos);
    public void StopMovenent() => _joystick.HideJoystick();
}
