using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehaviour : MonoBehaviour
{
    [Header("Layers to Smash")]
    [SerializeField] LayerMask _takeDamageLayer;
    private bool _isDead = false;
    public UnityEvent OnDead;

    public bool IsDead { get { return _isDead;  } }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        CheckKill(collision.gameObject.layer);

    }
    
    private void CheckKill(int layer)
    {
        if (((_takeDamageLayer.value & 1 << layer) == 1 << layer) && !_isDead)
        {
            Kill();
        }
    }

    internal void Kill()
    {
        _isDead = true;
        OnDead?.Invoke();
    }
}
