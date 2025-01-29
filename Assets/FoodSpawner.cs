using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject durianPrefab, meatOnStickPrefab, artichokePrefab;
    public int foodCount = 5;
    public Vector2 spawnArea = new Vector2(10, 5);

    void Start()
    {
        SpawnFood();
    }

    void SpawnFood()
    {
        for (int i = 0; i < foodCount; i++)
        {
            Vector3 spawnPos = new Vector3(
                UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
                UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
                0
            );

            GameObject foodItem = SelectFoodType();
            Instantiate(foodItem, spawnPos, Quaternion.identity);
        }
    }

    GameObject SelectFoodType()
    {
        int randomType = UnityEngine.Random.Range(0, 3);
        switch (randomType)
        {
            case 0: return durianPrefab;
            case 1: return meatOnStickPrefab;
            case 2: return artichokePrefab;
            default: return durianPrefab;
        }
    }
}
