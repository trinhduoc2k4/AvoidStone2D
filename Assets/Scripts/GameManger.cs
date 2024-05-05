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
    bool m_isRunGame;
    public float Score { get => score; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        if(gameUI && m_isRunGame)
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
        m_isRunGame = true;
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
        m_isRunGame = false;
    }
}

