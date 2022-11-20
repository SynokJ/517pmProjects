using System.Collections.Generic;
using UnityEngine;
using Rustem.Uitls;

public class CustomGrid : MonoBehaviour
{

    [Header("Grid Parameters:")]
    [SerializeField]
    private LayerMask _unwalkableMask;
    private float _nodeDiameter;
    private int _gridSizeX, _gridSizeY;

    [Header("Node Parameters:")]
    [SerializeField]
    private float _nodeRadius;
    private Vector3 _gridWorldSize;

    private Node[,] _grid;
    private List<Node> _path;

    private void Awake()
    {
        CustomUtils.GetCameraWorldSize(out float width, out float height);
        _gridWorldSize = new Vector3(width, height);

        _nodeDiameter = 2 * _nodeRadius;
        _gridSizeX = Mathf.RoundToInt(_gridWorldSize.x / _nodeDiameter);
        _gridSizeY = Mathf.RoundToInt(_gridWorldSize.y / _nodeDiameter);

        CreateGrid();
    }

    public void CreateGrid(Vector2 pos = default)
    {
        Vector2 offset = ((Vector2)transform.position - pos);

        _grid = new Node[_gridSizeX, _gridSizeY];
        //Vector2 worldBottomLeft = (Vector2)transform.position - new Vector2(_gridWorldSize.x / 2, _gridWorldSize.y / 2);
        Vector2 worldBottomLeft = pos - new Vector2(_gridWorldSize.x / 2, _gridWorldSize.y / 2);

        for (int x = 0; x < _gridSizeX; ++x)
            for (int y = 0; y < _gridSizeY; ++y)
            {
                Vector2 worldPoint = worldBottomLeft + new Vector2(x * _nodeDiameter + _nodeRadius, y * _nodeDiameter + _nodeRadius);

                bool walkable = !(Physics2D.OverlapCircle(worldPoint, _nodeRadius, _unwalkableMask));
                _grid[x, y] = new Node(walkable, worldPoint - offset, x, y);
            }

        DebugArray();
    }

    private void DebugArray()
    {
        string res = default;
        for (int r = 0; r < _grid.GetLength(0); ++r)
            for (int c = 0; c < _grid.GetLength(1); ++c)
                res += $"[{_grid[r, c].position.ToString()}] ";

        Debug.Log(res);
    }

    public Node GetNodeFromWorldPoint(Vector2 worldPosition)
    {
        float percentX = (worldPosition.x + _gridWorldSize.x / 2) / _gridWorldSize.x;
        float percentY = (worldPosition.y + _gridWorldSize.y / 2) / _gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((_gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((_gridSizeY - 1) * percentY);

        return _grid[x, y];
    }

    public List<Node> GetNeightbours(Node node)
    {
        List<Node> neightbours = new List<Node>();

        for (int x = -1; x <= 1; ++x)
            for (int y = -1; y <= 1; ++y)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < _gridSizeX && checkY >= 0 && checkY < _gridSizeY)
                    neightbours.Add(_grid[checkX, checkY]);
            }

        return neightbours;
    }

    public List<Node> GetPath() => _path;
    public void SetPath(List<Node> path) => _path = path;

    /// <summary>
    /// Debug current pathfinding grid
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(_gridSizeX, _gridSizeY));

        if (_grid != null)
        {
            foreach (Node n in _grid)
            {
                Gizmos.color = (n.isWalkable) ? Color.yellow : Color.red;
                if (_path != null && _path.Contains(n))
                    Gizmos.color = Color.black;

                Gizmos.DrawCube(n.position, Vector3.one * (_nodeDiameter - 0.1f));
            }
        }
    }
}
