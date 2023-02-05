using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    private bool _isCollected = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectableCatcherComponent collectable = collision.gameObject.GetComponent<CollectableCatcherComponent>();
        if (!_isCollected && collectable != null)
        {
            _isCollected = true;
            collectable.CatchCollectable();
            //habr�a que lanzar una animaci�n antes de desactivarlo, como con los enemigos
            gameObject.SetActive(false);
        }
    }
}
