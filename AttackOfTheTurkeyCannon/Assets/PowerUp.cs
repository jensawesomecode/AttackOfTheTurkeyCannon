using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, GravityAnchor, JumpBoost }
    public PowerUpType powerUpEffect;

    serializedField PlayerMovement

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                switch (powerUpEffect)
                {
                    case PowerUpType.SpeedBoost:
                        player.GetComponent<Rigidbody2D>().velocity *= 1.5f;
                        break;
                    case PowerUpType.GravityAnchor:
                        player.SetGravity(1.0f);
                        break;
                    case PowerUpType.JumpBoost:
                        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 10f);
                        break;
                }
            }
            Destroy(gameObject);
        }
    }
}
