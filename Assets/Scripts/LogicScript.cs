using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public int winScoreThreshold = 10;

    private float missionTimer = 0f;
    private bool hasWon = false;
    private bool hasLost = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip winClip;
    public AudioClip gameOverClip;

    void Start()
    {
        Debug.Log("Game Started in Mode: " + GameModeManager.SelectedMode);
        Time.timeScale = 1f;

        if (GameModeManager.SelectedMode == GameMode.Easy)
            winScoreThreshold = 10;
        else if (GameModeManager.SelectedMode == GameMode.Hard)
            winScoreThreshold = 20;
    }

    void Update()
    {
        if (hasWon || hasLost) return;

        if (GameModeManager.SelectedMode == GameMode.Mission)
        {
            missionTimer += Time.deltaTime;

            if (missionTimer >= 20f)
            {
                WinGame();
            }
        }
        else if (playerScore >= winScoreThreshold)
        {
            WinGame();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenuScene");
    }

    public void gameOver()
    {
        if (hasLost || hasWon) return;

        hasLost = true;
        StartCoroutine(PlayGameOver());
    }

    IEnumerator PlayGameOver()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.PlayOneShot(gameOverClip);
            yield return new WaitForSeconds(gameOverClip.length);
        }

        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void WinGame()
    {
        if (hasWon || hasLost) return;

        hasWon = true;

        if (audioSource != null && winClip != null)
        {
            audioSource.PlayOneShot(winClip);
        }

        Time.timeScale = 0f;
        winScreen.SetActive(true);
        Debug.Log("🎉 Player Wins!");
    }
}
