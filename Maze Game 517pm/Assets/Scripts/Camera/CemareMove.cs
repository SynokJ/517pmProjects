using UnityEngine;

public class CemareMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTr;
    [SerializeField] private Transform _cameraTr;

    private Vector3 _offset;

    private void Start() => _offset = _cameraTr.position - _playerTr.position;
    void FixedUpdate() => _cameraTr.position = _playerTr.position + _offset;
}
