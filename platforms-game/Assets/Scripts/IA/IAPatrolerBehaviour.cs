using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class IAPatrolerBehaviour : MonoBehaviour
{
    [SerializeField]
    private IAPatrolPathBehaviour _patrolBehaviour;

    [SerializeField]
    private EnemyController _enemyController;


    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
    }


    private void Update()
    {
        _patrolBehaviour.PerformAction(_enemyController);
    }
}
