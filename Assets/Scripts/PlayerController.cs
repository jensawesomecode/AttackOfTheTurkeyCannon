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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleShooting();

        if (Input.GetKeyDown(KeyCode.E))
        {
            UsePowerUp();
        }
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
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
        // Explicitly use UnityEngine.Random to avoid ambiguity
        int randomProjectile = UnityEngine.Random.Range(0, 3);
        GameObject projectile = null;

        switch (randomProjectile)
        {
            case 0: projectile = tomatoPrefab; break;
            case 1: projectile = eggPrefab; break;
            case 2: projectile = birdPrefab; break;
        }

        if (projectile != null)
        {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
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
}
