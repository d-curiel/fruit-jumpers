using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    IAMovement _iaMov;
    public IAMovement IAMovement { get => _iaMov; }
    private void Awake()
    {
        _iaMov = GetComponentInChildren<IAMovement>();
    }
    public void OnMovementInput(Vector2 movementDirection)
    {
        _iaMov.Move(movementDirection);
    }
}
