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

        AnalyzeTouchs();
    }

    private void AnalyzeTouchs()
    {
        if (Input.touchCount > 0)
        {
            _firstTouch = Input.GetTouch(0);

            if (_firstTouch.phase == TouchPhase.Began && CanStartMove())
                _walk.InitMovement(_firstTouch.position);
            else if (_firstTouch.phase == TouchPhase.Moved)
                _walk.OnMove(_firstTouch.position);
            else if (_firstTouch.phase == TouchPhase.Ended)
                _walk.StopMovenent();

        }
    }

    private bool CanStartMove()
        => !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(_firstTouch.fingerId);

    public void EnableGameSettings(UnityEngine.UI.Image image)
    {
        _canTrackTouches = true;
        image.color = Color.red;
    }
}
