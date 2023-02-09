using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehaviour : MonoBehaviour
{
    private bool _isDead = false;
    public UnityEvent OnDead;

    public bool IsDead { get { return _isDead;  } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isDead)
        {
            Kill();
        }
        
    }

    internal void Kill()
    {
        Debug.Log("Kill invoked");
        _isDead = true;
        OnDead?.Invoke();
    }
}
