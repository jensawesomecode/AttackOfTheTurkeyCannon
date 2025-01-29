using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject normalGroundPrefab;
    public GameObject lowGravityGroundPrefab;
    public GameObject quicksandGroundPrefab;

    public int width = 100;
    public int height = 100;
    public float tileSize = 1f;

    void Start()
    {
        GenerateGround();
        CreateBoundaries();
    }

    void GenerateGround()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * tileSize + tileSize / 2, y * tileSize + tileSize / 2, 0);
                GameObject selectedPrefab = SelectGroundType();
                Instantiate(selectedPrefab, position, Quaternion.identity);
            }
        }
    }

    GameObject SelectGroundType()
    {
        // Explicitly using UnityEngine.Random to resolve ambiguity
        int randomType = UnityEngine.Random.Range(0, 3);
        switch (randomType)
        {
            case 0: return normalGroundPrefab; // Normal gravity
            case 1: return lowGravityGroundPrefab; // Low gravity
            case 2: return quicksandGroundPrefab; // High gravity (sinking effect)
            default: return normalGroundPrefab;
        }
    }
    void CreateBoundaries()
    {
        float left = -width * tileSize / 2;
        float right = width * tileSize / 2;
        float bottom = -height * tileSize / 2;
        float top = height * tileSize / 2;

        CreateBoundary(new Vector2(left, (top + bottom) / 2), new Vector2(1, height * tileSize)); // Left
        CreateBoundary(new Vector2(right, (top + bottom) / 2), new Vector2(1, height * tileSize)); // Right
        CreateBoundary(new Vector2((left + right) / 2, top), new Vector2(width * tileSize, 1)); // Top
        CreateBoundary(new Vector2((left + right) / 2, bottom), new Vector2(width * tileSize, 1)); // Bottom
    }

    void CreateBoundary(Vector2 position, Vector2 size)
    {
        GameObject boundary = new GameObject("Boundary");
        boundary.transform.position = position;
        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = size;
    }

}
