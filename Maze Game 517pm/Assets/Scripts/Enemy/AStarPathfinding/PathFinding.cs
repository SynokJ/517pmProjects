using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    [Header("Grid Parameters: ")]
    [SerializeField]
    private CustomGrid _grid;

    private List<Node> _pathInstrcutions = new List<Node>();

    private List<Node> openSet = new List<Node>();
    private HashSet<Node> closedSet = new HashSet<Node>();

    private Node startNode;
    private Node targetNode;

    public void InitPath(Vector3 startPos, Vector3 targetPos)
    {
        if (targetPos == null || startPos == null)
        {
            ResetPathInstructions();
            return;
        }

        startNode = _grid.GetNodeFromWorldPoint(startPos);
        targetNode = _grid.GetNodeFromWorldPoint(targetPos);

        openSet.Clear();
        closedSet.Clear();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];

            for (int i = 1; i < openSet.Count; ++i)
                if (IsTheBestNode(currentNode, openSet[i]))
                {
                    currentNode = openSet[i];
                    break;
                }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                _pathInstrcutions = SetPathOnMap(startNode, targetNode);
                return;
            }

            foreach (Node neightbour in _grid.GetNeightbours(currentNode))
            {
                if (!neightbour.isWalkable || closedSet.Contains(neightbour))
                    continue;

                int newMovementCostToNeighbour = currentNode.gCost + GetDistanceBetweenNodes(currentNode, neightbour);
                if (newMovementCostToNeighbour < neightbour.gCost || !openSet.Contains(neightbour))
                {
                    neightbour.gCost = newMovementCostToNeighbour;
                    neightbour.hCost = GetDistanceBetweenNodes(neightbour, targetNode);
                    neightbour.parent = currentNode;

                    if (!openSet.Contains(neightbour))
                        openSet.Add(neightbour);
                }
            }
        }
    }

    private bool IsTheBestNode(Node current, Node other)
        => other.fCost < current.fCost || other.fCost == current.fCost && other.gCost < current.hCost;

    private List<Node> SetPathOnMap(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            if (!currentNode.isWalkable)
            {
                currentNode = currentNode.parent;
                continue;
            }

            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        _grid.SetPath(path);

        return path;
    }

    public List<Node> GetPath() => _pathInstrcutions;
    public void ResetPathInstructions() => _pathInstrcutions = new List<Node>();

    public int GetDistanceBetweenNodes(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
