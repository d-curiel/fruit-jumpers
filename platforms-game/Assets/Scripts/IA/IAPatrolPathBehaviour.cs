using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrolPathBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] _patrolPoints;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float _ArriveDistance = 1;
    private float _WaitingTime = 0.5f;
    [SerializeField]
    private bool _IsWaiting = false;
    [SerializeField]
    private bool _IsInitialized = false;
    [SerializeField]
    private int _currentIndex = 0;
    [SerializeField]
    private float _currentDistance;

    public void PerformAction(EnemyController controller)
    {
        if (!_IsWaiting)
        {
            if (_patrolPoints.Length < 2)
            {
                return;
            }

            if (!_IsInitialized)
            {
                var currentPathPoint = _patrolPoints[_currentIndex];
                _IsInitialized = true;
            }
            _currentDistance = Vector2.Distance(transform.position, _patrolPoints[_currentIndex].position);
            if (_currentDistance < _ArriveDistance)
            {
                _IsWaiting = true;
                StartCoroutine(Wait());
                return;
            }
            Vector2 directionToPatrol = (Vector2)_patrolPoints[_currentIndex].position - (Vector2)controller.IAMovement.transform.position;
            controller.OnMovementInput(directionToPatrol);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_WaitingTime);
        _currentIndex = (_currentIndex+1) % _patrolPoints.Length;
        _IsWaiting = false;

    }
}
