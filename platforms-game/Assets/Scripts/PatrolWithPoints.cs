using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PatrolMovement))]
public class PatrolWithPoints : MonoBehaviour
{
    [Header("Patrol Attributes")]
    [SerializeField] Transform[] _waypoints;
    int _nextWaypoint;

    PatrolMovement _patrolMovement;
    HandleAnimationOnLinearMove _animationsHandler;
    private void Awake()
    {
        _patrolMovement = GetComponent<PatrolMovement>();
    }

    private void Start()
    {
        _nextWaypoint = 0;
    }

    private void Update()
    {
        if(transform.position == _waypoints[_nextWaypoint].position)
        {
            _nextWaypoint = (_nextWaypoint + 1) % _waypoints.Length;
        } else
        {
            _patrolMovement.MoveToPoint(_waypoints[_nextWaypoint]);
        }
    }
}
