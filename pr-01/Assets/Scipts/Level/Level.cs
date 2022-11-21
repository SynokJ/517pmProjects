using UnityEngine;

public class Level
{
    private Vector2 _originPos;
    private Vector2 _spawnPos;

    private int _index;

    public Level(Vector2 origin, Vector2 spawn, int id)
    {
        _originPos = origin;
        _spawnPos = spawn;
        _index = id;
    }

    public void InitLevel(GameObject playerObj)
    {
        playerObj.transform.position = _spawnPos;
        Camera.main.transform.position = (Vector3)_originPos - Vector3.forward * 10.0f;
    }

    public void RedrawGrid()
    {

    }
}
