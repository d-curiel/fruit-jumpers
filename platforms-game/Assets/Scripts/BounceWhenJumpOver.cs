using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWhenJumpOver : MonoBehaviour
{
    public float jumpForce = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    }
}
