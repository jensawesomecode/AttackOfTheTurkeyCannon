using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float flapStrength = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        InvokeRepeating("Flap", 0.5f, 0.5f);
        Destroy(gameObject, 4f);
    }

    void Flap()
    {
        rb.velocity += Vector2.up * flapStrength; // Flaps upwards
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Birds hit and disappear
        }
    }
}
