using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeUI : MonoBehaviour
{
    public Transform[] lifeUIParents;

    private int currentLife = 3;
    private GameObject[] lifeUI;

    private void Start()
    {
        InitializeLifeUI();
    }

    private void InitializeLifeUI()
    {
        PlayerLife[] playerLifeScripts = GetComponents<PlayerLife>();

        for (int i = 0; i < currentLife; i++)
        {
            playerLifeScripts[i].gameObject.SetActive(true);
        }
    }

    public void DecreaseLife()
    {
        if (currentLife > 0)
        {
            currentLife--;
            PlayerLife[] playerLifeScripts = GetComponents<PlayerLife>();
            playerLifeScripts[currentLife].gameObject.SetActive(false);

            if (currentLife == 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {

    }
}
