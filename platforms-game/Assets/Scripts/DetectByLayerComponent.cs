using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectByLayerComponent : MonoBehaviour
{
    [Header("Layers")]
    [SerializeField]
    private LayerMask _layersToDetect;
    
    [Header("Events")]
    public UnityEvent OnDetect;

    private bool _detected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if ((_layersToDetect == (_layersToDetect | (1 << collision.gameObject.layer))) && !_detected)
        {
            Debug.Log("Entra? " + collision.gameObject.name);
            _detected = true;
            OnDetect?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _detected = false;
    }
}
