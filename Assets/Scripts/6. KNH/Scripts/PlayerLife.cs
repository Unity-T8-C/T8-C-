using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    public Text livesText;

    void Start()
    {
        currentLives = startingLives;
        UpdateLivesText();
    }
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }

    public void TakeDamage()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            UpdateLivesText();
        }
    }

    void GameOver()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
