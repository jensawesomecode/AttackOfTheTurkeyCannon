using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject chaserPrefab;
    public GameObject shooterPrefab;
    public GameObject patrollerPrefab;

    public int enemyCount = 5;
    public Vector2 spawnArea = new Vector2(10, 5);

    void Start()
    {
        GenerateEnemies();
    }

    void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0);
            GameObject selectedEnemy = SelectEnemyType();
            Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
        }
    }

    GameObject SelectEnemyType()
    {
        int randomType = Random.Range(0, 3);
        switch (randomType)
        {
            case 0: return chaserPrefab;
            case 1: return shooterPrefab;
            case 2: return patrollerPrefab;
            default: return chaserPrefab;
        }
    }
}
