using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    bool m_replayBtnClicked;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (gameObject.activeSelf) scoreText.text = "Your score: " + Mathf.RoundToInt(GameManger.Ins.Score).ToString();
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
            GameManger.Ins.GameStart();
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
