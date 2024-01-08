using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score = 0;

    private void Start()
    {
        SetText();
    }

    public int GetScore()
    {
        SetText();
        return score;
    }

    public void IncreaseScore(int amount = 100)
    {
        score += amount;
        SetText();
    }

    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }

}