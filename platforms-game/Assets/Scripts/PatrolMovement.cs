using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [Header("Movement Attributes")]
    [SerializeField] float _speed = 4f;

    public void MoveToPoint(Transform positionToPatrol)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionToPatrol.position, _speed * Time.deltaTime);
    }
}
