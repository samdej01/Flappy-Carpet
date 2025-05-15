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
    public int winScoreThreshold = 5;

    private float missionTimer = 0f;
    private bool hasWon = false;
    private bool hasLost = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip winClip;
    public AudioClip gameOverClip;

    [Header("Cup Progress")]
    public Image cupHolderImage;
    public Sprite silverCupSprite;
    public Sprite goldCupSprite;

    [Header("Scene Transition")]
    public string sceneToLoadAfterTwoObstacles = "UnlockedScene"; // Set this in the Inspector
    public string currentSceneMustBe = "GameScene"; // Only transition if this is the current scene

    void Start()
    {
        Debug.Log("Game Started in Mode: " + GameModeManager.SelectedMode);
        Time.timeScale = 1f;

        if (GameModeManager.SelectedMode == GameMode.Easy)
            winScoreThreshold = 10;
        else if (GameModeManager.SelectedMode == GameMode.Hard)
            winScoreThreshold = 20;

        Debug.Log("Win Score Threshold: " + winScoreThreshold);
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

        // Fallback win check for Easy & Hard modes
        if (playerScore >= winScoreThreshold && !hasWon)
        {
            WinGame();
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        Debug.Log("Score increased. Current score: " + playerScore);

        // Only transition if current scene is the first level
        if (playerScore == 5 && SceneManager.GetActiveScene().name == currentSceneMustBe)
        {
            Debug.Log("Passed 2 obstacles in first level – loading next scene.");
            SceneManager.LoadScene(sceneToLoadAfterTwoObstacles);
            return;
        }

        if (playerScore == 2 && cupHolderImage != null)
        {
            cupHolderImage.sprite = silverCupSprite;
            cupHolderImage.color = Color.white;
        }

        if (playerScore == 3 && cupHolderImage != null)
        {
            cupHolderImage.sprite = goldCupSprite;
        }

        if (playerScore >= winScoreThreshold && !hasWon)
        {
            WinGame();
        }
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
        Debug.Log("WinGame called – level complete!");

        if (audioSource != null && winClip != null)
        {
            audioSource.PlayOneShot(winClip);
        }

        // You can optionally load a scene here after win condition
        // SceneManager.LoadScene("WinScene");
    }
}
