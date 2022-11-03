using UnityEngine;

public abstract class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] protected Animator _anim;
    string _prevAnimName = default;

    //public abstract void SetBoolByName();

    protected virtual void PlayAnimationByName(string name)
    {
        if (!string.IsNullOrEmpty(_prevAnimName))
            _anim.SetBool(name, false);

        _anim.SetBool(name, true);
        _prevAnimName = name;
    }
}
