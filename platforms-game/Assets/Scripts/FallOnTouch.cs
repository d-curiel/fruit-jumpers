using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (Rigidbody))]
public class FallOnTouch : MonoBehaviour
{

    

    [Header("Components")]
    Animator _animator;
    Rigidbody2D _rb;

    [Header("Configuration Variables")]
    [SerializeField] float _secondsToFall = 2f;

    [Header("Events")]
    public UnityEvent OnFall;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ChangeGravity());
    }

    IEnumerator ChangeGravity()
    {
        yield return new WaitForSeconds(_secondsToFall);
        _animator.SetBool("Fall", true);
        yield return new WaitForSeconds(_secondsToFall);
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.gravityScale = 1;
        _rb.AddForce(new Vector2(0, 1));
        OnFall?.Invoke();
    }
}
