using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrolPathBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform[] _patrolPoints;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float _arriveDistance = 1;
    private float _waitingTime = 0.5f;
    [SerializeField]
    private bool _isWaiting = false;
    [SerializeField]
    private int _currentIndex = 0;
    [SerializeField]
    private float _currentDistance;

    public void PerformAction(EnemyController controller)
    {
        if (!_isWaiting)
        {
            if (_patrolPoints.Length < 2)
            {
                return;
            }

            _currentDistance = Vector2.Distance(transform.position, _patrolPoints[_currentIndex].position);
            if (_currentDistance <= _arriveDistance)
            {
                _isWaiting = true;
                StartCoroutine(Wait());
                return;
            }
            Vector2 directionToPatrol = (Vector2)_patrolPoints[_currentIndex].position - (Vector2)controller.IAMovement.transform.position;
            controller.OnMovementInput(directionToPatrol);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_waitingTime);
        _currentIndex = (_currentIndex+1) % _patrolPoints.Length;
        _isWaiting = false;

    }
}
