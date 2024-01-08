using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private ProjectileManager _projectileManager;

    public GameObject Player;

    public GameObject endPanel;
    public Text timeText;   //½Ã°£
    float alive = 0f;

    private bool live;

    private float initialTime;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                _instance = go.GetComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);

            initialTime = Time.timeScale;
        }
        else
        {
            if (_instance != this) Destroy(this);
        }
        live = true;
    }

    private void Update()
    {
        if (live)
        {
            alive += Time.deltaTime;
            //timeText.text = alive.ToString("N2");
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        endPanel.SetActive(true);
    }

    public void retry()
    {
        ResetGame();
        _projectileManager.ResetProjectiles();
        SceneManager.LoadScene("MainScene");
    }

    public void PlayerDie()
    {
        live = false;
        gameOver();
    }

    private void ResetGame()
    {
        Time.timeScale = initialTime;
        alive = 0.0f;
        live = true;
        endPanel.SetActive(false);

        if (Player != null)
        {
            if (!Player.activeSelf)
            {
                Player.SetActive(true);
            }
        }
    }
}
