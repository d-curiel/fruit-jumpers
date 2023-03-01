using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehaviour : MonoBehaviour
{
    [Header("Layers to Smash")]
    [SerializeField] 
    LayerMask _takeDamageLayerMask;
    private bool _isDead = false;
    public UnityEvent OnDead;
    public UnityEvent onAfterDead;

    public bool IsDead { get { return _isDead;  } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryToKill(collision.gameObject.layer);
    }
    
    internal void TryToKill(int layer)
    {
        if ((_takeDamageLayerMask == (_takeDamageLayerMask | (1 << layer))) && !_isDead)
        {
            _isDead = true;
            OnDead?.Invoke();
        }
    }

    public void InvoleOnDead()
    {
        onAfterDead?.Invoke();
    }
}
