using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HandleAnimationOnLinearMove : MonoBehaviour
{
    private Animator _animator;
    protected Vector2 direction = Vector2.zero;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Animate();
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    public void Animate()
    {
        _animator.SetFloat("HorizontalDirection", direction.x);
        _animator.SetFloat("VerticalDirection", direction.y);
    }
}
