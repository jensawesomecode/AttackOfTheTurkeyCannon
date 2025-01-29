using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float defaultGravity = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetGravity(defaultGravity);
    }

    public void SetGravity(float gravityScale)
    {
        rb.gravityScale = gravityScale;
    }
}
