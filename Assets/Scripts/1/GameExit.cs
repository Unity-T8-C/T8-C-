using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    // ���� ���� �޼ҵ�
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("���� �����"); // �����Ϳ��� Ȯ�ο�
    }
}
