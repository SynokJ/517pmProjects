using UnityEngine;

public abstract class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] protected Animator _anim;
    string _prevAnimName = default;

    protected virtual void PlayAnimationByName(string name)
    {
        if (_prevAnimName != null && !_prevAnimName.Equals(name))
            return;

        if (!string.IsNullOrEmpty(_prevAnimName))
            _anim.SetBool(name, false);

        _anim.SetBool(name, true);
        _prevAnimName = name;
    }
}
