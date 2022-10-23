using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool isWalkable;
    public Vector3 position;

    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;

    public Node parent;

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public Node(bool isWalkable, Vector3 position)
    {
        this.isWalkable = isWalkable;
        this.position = position;
    }

    public Node(bool isWalkable, Vector3 position, int gridX, int gridY)
    {
        this.isWalkable = isWalkable;
        this.position = position;
        this.gridX = gridX;
        this.gridY = gridY;
    }
}
