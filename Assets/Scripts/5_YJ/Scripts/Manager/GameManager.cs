using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Player;

    public GameObject endPanel;
    public Text timeText;   //�ð�
    float alive = 60f;

    private bool live;

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
        //set
        //{
        //    if (_instance == null) _instance = value;
        //}
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
        }

        live = true;

        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }

        PlayerLife playerLife = Player.GetComponent<PlayerLife>();
        if (playerLife != null)
        {
            playerLife.SetGameManager(this);
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (live)
        {
            alive -= Time.deltaTime;
            timeText.text = alive.ToString("N2");

            if(alive >= 60f)
            {
                PlayerDie();
            }
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        endPanel.SetActive(true);
    }

    public void retry()
    {
        alive = Time.deltaTime;

        live = true;
        endPanel.SetActive(false);

        SceneManager.LoadScene("MainScene");
    }

    public void PlayerDie()
    {
        live = false;
        gameOver();
    }
}
