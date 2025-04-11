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

    private float missionTimer = 0f;
    private bool hasWon = false;

    void Start()
    {
        Debug.Log("Game Started in Mode: " + GameModeManager.SelectedMode);
        Time.timeScale = 1f; // Ensure time is unpaused if coming back from win/game over
    }

    void Update()
    {
        if (GameModeManager.SelectedMode == GameMode.Mission && !hasWon)
        {
            missionTimer += Time.deltaTime;

            if (missionTimer >= 30f)
            {
                win();
            }
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenuScene");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void win()
    {
        hasWon = true;
        Time.timeScale = 0f; 
        winScreen.SetActive(true); 
        Debug.Log("Survived Mission Mode");
    }
}