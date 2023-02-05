using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class IAMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    Vector2 _currentMovement;

    [Header("Movement Variables")]
    [SerializeField] private float speed = 4f;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _sr = GetComponentInParent<SpriteRenderer>();
    }

    public void Move(Vector2 movementVector)
    {
        this._currentMovement = movementVector;

    }

    private void FixedUpdate()
    {
        _sr.flipX = _currentMovement.x > 0;
        _rb.velocity = (Vector2)transform.right * _currentMovement.normalized.x * speed * Time.fixedDeltaTime;
    }
}
