using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    // 게임 종료 메소드
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("게임 종료됨"); // 에디터에서 확인용
    }
}
