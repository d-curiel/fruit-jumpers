using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHitComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.gameObject.SetActive(false);
    }
}
