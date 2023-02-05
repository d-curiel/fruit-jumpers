using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [Header("Bullet Data")]
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _damage;

    private Vector2 _startPosition;
    private float _conquaredDistance;
    [Header("Components")]
    private Rigidbody2D _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Init(float maxDistance, float speed, int damage)
    {
        this._maxDistance = maxDistance;
        this._speed = speed;
        _startPosition = transform.position;
        _rb.velocity = transform.right * _speed;

    }

    void Update()
    {
        _conquaredDistance = Vector2.Distance(_startPosition, transform.position);
        if(_conquaredDistance > _maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
        _rb.velocity = Vector2.zero;
    }
}
