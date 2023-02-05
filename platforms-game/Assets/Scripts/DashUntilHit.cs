using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUntilHit : MonoBehaviour
{
    [Header("Configuration Variables")]
    [SerializeField] float _smashForce;
    [SerializeField] float _smashDelay;

    [Header("Layers to Smash")]
    [SerializeField] LayerMask _smashLayer;

    [Header("Movement Directions")]
    [SerializeField] Vector2 _positiveSmashDirection;
    [SerializeField] Vector2 _negativeSmashDirection;
    
    [Header("Animations")]
    [SerializeField] AnimationClip _positiveAnimation;
    [SerializeField] AnimationClip _negativeAnimation;
    
    Rigidbody2D _rb;
    Animator _animator;
    Vector2 _smashDirection;
    Vector2 _lastSmashDirection;
    bool _hasSmashed = false;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _smashDirection = _positiveSmashDirection;
        _lastSmashDirection = _smashDirection;
    }

    private void Start()
    {
        Smash();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((_smashLayer.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer) && !_hasSmashed)
        {
            _hasSmashed = true;
            if (_smashDirection.x > 0 || _smashDirection.y > 0)
            {
                _animator.Play(_positiveAnimation.name);
            }
            else if (_smashDirection.x < 0 || _smashDirection.y < 0)
            {
                _animator.Play(_negativeAnimation.name);
            }
            StartCoroutine(WaitForNextSmash());
        }
    }

    private void Smash()
    {
        _rb.AddForce(_smashDirection * _smashForce, ForceMode2D.Impulse);
        _hasSmashed = false;
    }
    IEnumerator WaitForNextSmash()
    {
        _smashDirection = Vector2.zero;
        yield return new WaitForSeconds(_smashDelay);
        _smashDirection = _lastSmashDirection == _positiveSmashDirection ? _negativeSmashDirection : _positiveSmashDirection;
        _lastSmashDirection = _smashDirection;
        Smash();
    }
}
