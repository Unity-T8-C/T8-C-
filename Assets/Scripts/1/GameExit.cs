using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    // ���� ���� �޼ҵ�
    public void QuitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}