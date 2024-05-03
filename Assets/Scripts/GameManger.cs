using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : Singleton<GameManger>
{
    public RockSpawner rockSpawner;
    public PlayerSpawn playerSpawn;
    public GameObject gameStartUI, gameUI, gameOverUI;
    float score = 0;
    bool m_replayBtnClicked;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public override void Awake()
    {
        MakeSingleton(false);
    }


    public override void Start()
    {
        base.Start();

        AudioController.Ins.PlayBackgroundMusic();
    }
    private void Update()
    {
        if(gameUI)
        {
            TextMeshProUGUI scoreText = gameUI.GetComponentInChildren<TextMeshProUGUI>();
            score += Time.deltaTime;
            scoreText.text = Mathf.RoundToInt(score).ToString();
        }
    }

    public void GameStart()
    {
        StartCoroutine(RunGame());
        gameStartUI.SetActive(false);
        gameUI.SetActive(true);
    }

    IEnumerator RunGame()
    {
        if (playerSpawn) playerSpawn.Spawn();
        yield return new WaitForSeconds(1);
        if (rockSpawner) StartCoroutine(rockSpawner.SpawnRock());
    }

    public void ShowGameOverUI()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true); 
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Replay()
    {
        m_replayBtnClicked = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (m_replayBtnClicked)
        {
            GameStart();
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

