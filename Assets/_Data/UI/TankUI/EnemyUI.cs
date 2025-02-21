using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public GameObject enemyIconPrefab;
    public Transform enemyContainer;

    private int enemyCount = 20;

    void Start()
    {
        UpdateEnemyDisplay();
    }

    public void UpdateEnemyDisplay()
    {
        foreach (Transform child in enemyContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyIconPrefab, enemyContainer);
        }
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
        UpdateEnemyDisplay();
    }
}