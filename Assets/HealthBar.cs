using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform healthContainer;

    private List<GameObject> hearts = new List<GameObject>();

    void Start()
    {
        UpdateHealth(5);
    }

    public void UpdateHealth(int health)
    {
        foreach (var heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();

        for (int i = 0; i < health; i++)
        {
            GameObject heart = Instantiate(heartPrefab, healthContainer);
            hearts.Add(heart);
        }
    }
}
