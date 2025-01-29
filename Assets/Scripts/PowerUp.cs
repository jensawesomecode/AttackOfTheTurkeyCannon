using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, GravityAnchor, JumpBoost }
    public PowerUpType powerUpEffect;

    [SerializeField]
    private PlayerMovement playerMovement; // Corrected the misplaced brackets

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>(); // Optimize by calling GetComponent only once

            if (player != null && rb != null)
            {
                switch (powerUpEffect)
                {
                    case PowerUpType.SpeedBoost:
                        rb.velocity *= 1.5f;
                        break;
                    case PowerUpType.GravityAnchor:
                        player.SetGravity(1.0f);
                        break;
                    case PowerUpType.JumpBoost:
                        rb.velocity = new Vector2(rb.velocity.x, 10f);
                        break;
                }
            }
            Destroy(gameObject); // Destroy the power-up after application
        }
    }
}
