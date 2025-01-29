using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject normalGroundPrefab;
    public GameObject lowGravityGroundPrefab;
    public GameObject quicksandGroundPrefab;

    public int width = 10;
    public int height = 5;
    public float tileSize = 1f;

    void Start()
    {
        GenerateGround();
    }

    void GenerateGround()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
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
}
