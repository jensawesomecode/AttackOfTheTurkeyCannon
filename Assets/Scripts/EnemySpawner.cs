using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance; // Singleton instance

    public GameObject chaserPrefab;
    public GameObject shooterPrefab;
    public GameObject patrollerPrefab;

    public int enemyCount = 5;
    public Vector2 spawnArea = new Vector2(10, 5);

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    void Start()
    {
        GenerateEnemies();
    }

    // Spawns multiple enemies when the game starts
    void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    // Spawns a single enemy at a random location
    public void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
            0
        );

        GameObject selectedEnemy = SelectEnemyType();
        Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
    }

    // Selects a random enemy type
    GameObject SelectEnemyType()
    {
        int randomType = UnityEngine.Random.Range(0, 3);
        switch (randomType)
        {
            case 0: return chaserPrefab;
            case 1: return shooterPrefab;
            case 2: return patrollerPrefab;
            default: return chaserPrefab;
        }
    }
}
