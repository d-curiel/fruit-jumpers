using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageableBehaviour db = collision.GetComponent<DamageableBehaviour>();
        RestartObjectPosition rop = collision.GetComponent<RestartObjectPosition>();
        if(rop != null)
        {
            rop.RestartPosition();
        }
    }
}
