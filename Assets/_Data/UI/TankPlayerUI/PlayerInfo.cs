using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public Image playerTankIcon;

    private int playerLives = 3;

    void Start()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {
        livesText.text = playerLives.ToString();
    }

    public void ReduceLife()
    {
        if (playerLives > 0)
        {
            playerLives--;
            UpdateLives();
        }
        else if (playerLives == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}