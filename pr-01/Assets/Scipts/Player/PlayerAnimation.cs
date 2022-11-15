using UnityEngine;

public class PlayerAnimation : AnimationSwitcher
{
    private const string _MOVE_UP = "move_up";
    private const string _MOVE_RIGHT = "move_right";
    private const string _MOVE_LEFT = "move_left";

    public void SetAnimationByDirection(Vector2 dir)
    {
        if (dir.y > 0 && dir.x > 0 && dir.x < 0.5f)
            PlayAnimationByName(_MOVE_UP);
        else if (dir.x > 0)
            PlayAnimationByName(_MOVE_RIGHT);
        else if (dir.x < 0)
            PlayAnimationByName(_MOVE_LEFT);
    }

    public void ResetAnimations()
    {
        _anim.SetBool(_MOVE_UP, false);
        _anim.SetBool(_MOVE_LEFT, false);
        _anim.SetBool(_MOVE_RIGHT, false);
    }
}
