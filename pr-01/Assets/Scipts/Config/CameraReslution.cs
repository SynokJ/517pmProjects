using UnityEngine;

public class CameraReslution : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _sceneTr;
    [SerializeField] private Sprite _sprite;
    private Vector2 _sceneSize;

    private float _unitsPerPixel;

    void Awake()
    {
        _sceneSize = _sceneTr.localScale;
        _517pm.Debugger.CustomDebugger.PrintContextWithTime(_sceneSize.ToString(), true);

        _unitsPerPixel = _sceneSize.x / Screen.width;
        float desiredHalfHeight = 0.5f * _unitsPerPixel * Screen.height;

        _camera.orthographicSize = desiredHalfHeight * _sprite.pixelsPerUnit;

        Destroy(this);
    }
}
