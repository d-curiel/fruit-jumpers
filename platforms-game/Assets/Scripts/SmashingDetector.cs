using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmashingDetector : MonoBehaviour
{
    DamageableBehaviour _damageableBehaviour;

    private void Awake()
    {
        _damageableBehaviour = GetComponentInParent<DamageableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_damageableBehaviour != null)
        {
            _damageableBehaviour.Kill();
        }
    }


}
