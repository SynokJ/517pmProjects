using System.Collections.Generic;
using UnityEngine;

public class MoveNextLevel : MonoBehaviour
{
    [Header("Grid Parameters: ")]
    [SerializeField] private CustomGrid _grid;
    [SerializeField] private List<Transform> _mapPos = new List<Transform>();

    [Header("Player Parameters: ")]
    [SerializeField] private List<Transform> _spawnPos = new List<Transform>();
    [SerializeField] private GameObject _gameObject;

    private int _curLevel = 0;

    public void DrawNextLevel()
    {
        _grid.CreateGrid(_mapPos[_curLevel++].position);
        _gameObject.transform.position = _spawnPos[_curLevel].position;
        Camera.main.transform.position = _mapPos[_curLevel].position - Vector3.forward * 10.0f;

        _517pm.Debugger.CustomDebugger.PrintContextWithTime(_mapPos[_curLevel].position.ToString(), true);
    }
}