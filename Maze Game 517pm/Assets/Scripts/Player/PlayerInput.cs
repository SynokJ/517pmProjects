using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerWalk _walk;

    private bool _canTrackTouches = false;
    private Touch _firstTouch;

    void Update()
    {
        if (!_canTrackTouches)
            return;
    }
    private bool CanStartMove()
        => !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(_firstTouch.fingerId);

    public void EnableGameSettings(UnityEngine.UI.Image image)
    {
        _canTrackTouches = true;
        image.color = Color.red;
    }
}
