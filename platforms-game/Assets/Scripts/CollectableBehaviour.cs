using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableBehaviour : MonoBehaviour
{
    private bool _isCollected = false;
    public UnityEvent OnCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectableCatcherComponent collectable = collision.gameObject.GetComponent<CollectableCatcherComponent>();
        if (!_isCollected && collectable != null)
        {
            _isCollected = true;
            collectable.CatchCollectable();
            OnCollect?.Invoke();
        }
    }
}
