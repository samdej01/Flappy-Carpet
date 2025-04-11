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

    void Start()
    {
        Debug.Log("Game Started in Mode: " + GameModeManager.SelectedMode);
    }
 
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
 
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}