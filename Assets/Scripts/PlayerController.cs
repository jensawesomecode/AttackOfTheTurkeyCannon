using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform firePoint; // Where projectiles spawn from
    public GameObject tomatoPrefab;
    public GameObject eggPrefab;
    public GameObject birdPrefab;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool hasPowerUp = false;
    private int health = 5; // Starts with 5 health

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        if (Input.GetMouseButtonDown(0)) // Left Click for shooting
        {
            Shoot();
        }
    }


    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Select a random projectile
        GameObject projectile = SelectProjectile();

        if (projectile != null)
        {
            // Instantiate the projectile at the firePoint position
            GameObject newProjectile = Instantiate(projectile, firePoint.position, Quaternion.identity);

            // Apply velocity to shoot it forward
            Rigidbody2D projRb = newProjectile.GetComponent<Rigidbody2D>();
            if (projRb != null)
            {
                projRb.velocity = transform.right * 10f; // Shoots in the direction the player is facing
            }
        }
    }

    // SelectProjectile() method for better modularity
    GameObject SelectProjectile()
    {
        int randomProjectile = UnityEngine.Random.Range(0, 3);
        switch (randomProjectile)
        {
            case 0: return tomatoPrefab;
            case 1: return eggPrefab;
            case 2: return birdPrefab;
            default: return tomatoPrefab;
        }
    }


    void UsePowerUp()
    {
        if (hasPowerUp)
        {
            UnityEngine.Debug.Log("Power-Up Activated!"); // Explicitly using UnityEngine.Debug to resolve ambiguity
            hasPowerUp = false; // Assume single-use power-ups
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void GrantPowerUp()
    {
        hasPowerUp = true;
    }
    public void Heal(int amount)
    {
        health = Mathf.Min(10, health + amount); // Cap at 10 health
        FindObjectOfType<HealthBar>().UpdateHealth(health);
    }
}
