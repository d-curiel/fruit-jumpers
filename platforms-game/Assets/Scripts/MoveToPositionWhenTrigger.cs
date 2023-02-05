using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionWhenTrigger : MonoBehaviour
{
    [SerializeField] private Transform positionToMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = positionToMove.position;
    }
}
