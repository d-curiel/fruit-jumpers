using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartObjectPosition : MonoBehaviour
{
    Rigidbody2D _rb;
    RigidbodyType2D _rbType;
    float _rbGravity;
    Collider2D _cd;
    [Header("Delay Configuration")]
    [SerializeField] float _restartDealy;
    [SerializeField] float _restartDealyDuration;
    [SerializeField] float _restartSpeed;
    Vector2 _initialPosition;
    [Header("Events")]
    public UnityEvent OnRestart;
    public UnityEvent OnFinish;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cd = GetComponent<Collider2D>();
        _rbType = _rb.bodyType;
        _rbGravity = _rb.gravityScale;
    }
    private void Start()
    {
        _initialPosition = transform.position;
    }

    public void RestartPosition()
    {
        StartCoroutine(AwaitForRestartPosition());
    }

    IEnumerator AwaitForRestartPosition()
    {
        _rb.bodyType = _rbType;
        _rb.gravityScale = _rbGravity;
        _rb.velocity = Vector2.zero;
        _cd.enabled = false;
        OnRestart?.Invoke();
        yield return new WaitForSeconds(_restartDealy);
        while ((Vector2)transform.position != _initialPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _initialPosition, _restartSpeed * Time.fixedDeltaTime); 
            yield return new WaitForSeconds(_restartDealyDuration);
        }
        _cd.enabled = true;
        OnFinish?.Invoke();
    }

}
