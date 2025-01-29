using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject speedBoostPrefab;
    public GameObject gravityAnchorPrefab;
    public GameObject jumpBoostPrefab;

    public int powerUpCount = 3;
    public Vector2 spawnArea = new Vector2(10, 5);

    void Start()
    {
        GeneratePowerUps();
    }

    void GeneratePowerUps()
    {
        for (int i = 0; i < powerUpCount; i++)
        {
            // Use UnityEngine.Random to generate the spawn position
            Vector3 spawnPosition = new Vector3(
                UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
                UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
                0
            );

            GameObject selectedPowerUp = SelectPowerUpType();
            Instantiate(selectedPowerUp, spawnPosition, Quaternion.identity);
        }
    }

    GameObject SelectPowerUpType()
    {
        // Use UnityEngine.Random instead of System.Random
        int randomType = UnityEngine.Random.Range(0, 3);

        switch (randomType)
        {
            case 0: return speedBoostPrefab;
            case 1: return gravityAnchorPrefab;
            case 2: return jumpBoostPrefab;
            default: return speedBoostPrefab;
        }
    }
}
