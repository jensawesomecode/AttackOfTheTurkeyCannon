using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public void SetDifficultyBeginner()
    {
        GameManager.Instance.SetDifficulty(0);
        SceneManager.LoadScene("GameScene");
    }

    public void SetDifficultyIntermediate()
    {
        GameManager.Instance.SetDifficulty(1);
        SceneManager.LoadScene("GameScene");
    }

    public void SetDifficultyHard()
    {
        GameManager.Instance.SetDifficulty(2);
        SceneManager.LoadScene("GameScene");
    }
}
