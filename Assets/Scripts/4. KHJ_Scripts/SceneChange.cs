using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MainScenesChange()
    { 
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }

    public void StartScenesChange()
    {
        SceneManager.LoadScene("StartScene");
    }
}
