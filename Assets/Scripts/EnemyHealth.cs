using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject); // Destroy enemy if health reaches zero
            }
        }
    }
}
