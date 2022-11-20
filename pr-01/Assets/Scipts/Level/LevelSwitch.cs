using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    [Header("Grid Parameters: ")]
    [SerializeField] private CustomGrid _grid;
    [SerializeField] private List<Transform> _mapPos = new List<Transform>();

    [Header("Player Parameters: ")]
    [SerializeField] private List<Transform> _spawnPos = new List<Transform>();
    [SerializeField] private GameObject _playerObj;

    private int _curLevel = 0;
    private List<Level> _levels = new List<Level>();

    private void Start()
    {
        if (_mapPos.Count != _spawnPos.Count)
            return;

        InitLevels();
    }

    public void MoveNextLevel()
    {
        _curLevel++;

        if (_curLevel >= _levels.Count)
            _curLevel = 0;


        _grid.CreateGrid(_mapPos[_curLevel].position);
        _levels[_curLevel].InitLevel(_playerObj);

        _517pm.Debugger.CustomDebugger.PrintContextWithTime(_mapPos[_curLevel].position.ToString(), true);
    }

    public void MovePreviousLevel()
    {

    }

    private void InitLevels()
    {
        for (int i = 0; i < _mapPos.Count; ++i)
            _levels.Add(new Level(_mapPos[i].position, _spawnPos[i].position, i));
    }
}