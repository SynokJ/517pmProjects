using UnityEngine;

public class JoyStick : MonoBehaviour
{

    [Header("Joystick's Grafix")]
    public Transform innerCircle;
    public Transform outerCircle;

    [Header("Joystick Parameters")]
    public Vector2 vec;
    Vector2 firstTouch;

    [Header("Radius of Outer Circle")]
    float radius;

    private UnityEngine.UI.Image _joystickRenderer;
    private UnityEngine.UI.Image _borderRenderer;

    private void Start()
    {
        _joystickRenderer = innerCircle?.GetComponent<UnityEngine.UI.Image>();
        _borderRenderer = outerCircle?.GetComponent<UnityEngine.UI.Image>();

        radius = outerCircle.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void PointerDown()
    {
        innerCircle.position = Input.mousePosition;
        outerCircle.position = Input.mousePosition;
        firstTouch = Input.mousePosition;

        ShowJoystick();
    }

    // stop to touch the Screen
    public void PointerUp()
    {
        HideJoystick();
        vec = Vector2.zero;
    }

    // drag the finger on Screen 
    public void Drag(UnityEngine.EventSystems.BaseEventData bed)
    {
        UnityEngine.EventSystems.PointerEventData ped = bed as UnityEngine.EventSystems.PointerEventData;
        Vector2 dragPos = ped.position;

        vec = (dragPos - firstTouch).normalized;
        float dist = Vector2.Distance(dragPos, firstTouch);
        innerCircle.position = firstTouch + vec * (dist < radius ? dist : radius);
    }

    public void ShowJoystick()
    {
        _joystickRenderer.enabled = true;
        _borderRenderer.enabled = true;
    }

    public void HideJoystick()
    {
        _joystickRenderer.enabled = false;
        _borderRenderer.enabled = false;
    }
}