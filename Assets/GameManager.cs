using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int playerHealth = 5;
    public int score = 0;
    public float gameTimer = 0f;
    public float survivalGoal = 180f; // Default: 3 minutes to win
    public float enemySpawnRate = 5f; // Default: Spawn every 5 seconds

    public Text timerText;
    public Text winLoseText;

    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Default to Intermediate if no difficulty set
        if (!PlayerPrefs.HasKey("Difficulty")) SetDifficulty(1);

        InvokeRepeating("SpawnEnemy", 2f, enemySpawnRate); // Start enemy spawns
    }

    void Update()
    {
        if (!gameEnded)
        {
            gameTimer += Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(gameTimer);

            if (gameTimer >= survivalGoal)
            {
                WinGame();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        FindObjectOfType<HealthBar>().UpdateHealth(playerHealth);

        if (playerHealth <= 0)
        {
            LoseGame();
        }
    }

    void SpawnEnemy()
    {
        EnemySpawner.Instance.SpawnEnemy();
    }

    public void SetDifficulty(int level)
    {
        switch (level)
        {
            case 0: // Beginner
                survivalGoal = 240f; // Survive 4 minutes
                enemySpawnRate = 6f; // Slower spawns
                break;
            case 1: // Intermediate
                survivalGoal = 180f; // Survive 3 minutes
                enemySpawnRate = 4.5f; // Moderate spawns
                break;
            case 2: // Hard
                survivalGoal = 120f; // Survive 2 minutes
                enemySpawnRate = 3f; // Fast spawns
                break;
        }

        PlayerPrefs.SetInt("Difficulty", level);
        PlayerPrefs.Save();
    }

    void WinGame()
    {
        gameEnded = true;
        winLoseText.text = "You Survived!";
        Invoke("RestartGame", 3f);
    }

    void LoseGame()
    {
        gameEnded = true;
        winLoseText.text = "You Died!";
        Invoke("RestartGame", 3f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
