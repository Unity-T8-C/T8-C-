using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Player;

    public GameObject endPanel;
    public Text timeText;   //½Ã°£
    float alive = 0f;

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
        }
        else
        {
            if (_instance != this) Destroy(this);
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()   
    {
        alive += Time.deltaTime;
        timeText.text = alive.ToString("N2");
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        endPanel.SetActive(true);
    }


    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
