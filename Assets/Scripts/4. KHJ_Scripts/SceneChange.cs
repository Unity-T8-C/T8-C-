using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MainScenesChange()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartScenesChange()
    {
        SceneManager.LoadScene("StartScene");
    }

}
