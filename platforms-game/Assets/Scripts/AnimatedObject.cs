using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimatedObject : MonoBehaviour
{
    [Header("Components")]
    private Animator _animator;


    public UnityEvent OnPropertyChange;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeBool(string name, bool value)
    {
        _animator.SetBool(name, value);
        OnPropertyChange?.Invoke();
    }
    public void ActivateBool(string name)
    {
        ChangeBool(name, true);
        OnPropertyChange?.Invoke();
    }
    public void DeactivateBool(string name)
    {
        ChangeBool(name, false);
        OnPropertyChange?.Invoke();
    }
}
