using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageableBehaviour))]
public class DetectJumpOver : MonoBehaviour
{
    private DamageableBehaviour _db;
    private float _bounceForce = 6f;

    private void Awake()
    {
        _db = GetComponent<DamageableBehaviour>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_db.IsDead)
        {

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {

                Vector2 direction = transform.position - collision.transform.position;
                if (Vector2.Dot(direction.normalized, Vector2.down) > 0.15f)
                {
                    rb.velocity = Vector2.up;
                    rb.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);
                    _db.Kill();
                }
            }
        }
    }
}
