using UnityEngine;

public class JoyStick : MonoBehaviour
{

    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _border;

    private UnityEngine.UI.Image _joystickRenderer;
    private UnityEngine.UI.Image _borderRenderer;

    private Vector2 _halfOfSize;
    private float _posX;
    private float _posY;

    private void Awake()
    {
        _joystickRenderer = _joystick?.GetComponent<UnityEngine.UI.Image>();
        _borderRenderer = _border?.GetComponent<UnityEngine.UI.Image>();

        _halfOfSize = GetComponent<RectTransform>().sizeDelta;
    }

    public void ShowJoystick(Vector2 pos)
    {
        _joystickRenderer.enabled = true;
        _borderRenderer.enabled = true;

        transform.position = pos - _halfOfSize;
    }

    public void MoveJoystick(Vector2 pos)
    {
        _posX = Mathf.Clamp(pos.x - transform.position.x, -_halfOfSize.x / 4, _halfOfSize.x);
        _posY = Mathf.Clamp(pos.y - transform.position.y, -_halfOfSize.y / 4, _halfOfSize.y);

        _joystick.transform.position = transform.position + new Vector3(_posX, _posY) + (Vector3)_halfOfSize/2;
    }

    public void HideJoystick()
    {
        _joystickRenderer.enabled = false;
        _borderRenderer.enabled = false;
    }
}