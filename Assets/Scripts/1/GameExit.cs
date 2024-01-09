using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    // 게임 종료 메소드
    public void QuitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}