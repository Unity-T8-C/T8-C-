using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    //public PlayerLifeUI playerLifeUI;
    private GameManager gameManager;
    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    //public int startingLives = 3;
    //public Text livesText;
    public int currentLives = 3;


    void Start()
    {
        //currentLives = startingLives;
        //UpdateLivesText();
    }
    //void UpdateLivesText()
    //{
    //    livesText.text = "Lives: " + currentLives.ToString();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            PlayerDie();
        }
        else
        {
            //UpdateLivesText();
        }
    }

    private void PlayerDie()
    {
        if (gameManager != null)
        {
            gameManager.PlayerDie();
        }
    }
}
