using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private List<Transform> _destinationPoints = new List<Transform>();
    [SerializeField] private PathFinding _pathFinding;

    private void SetDestination()
    {

    }
}
