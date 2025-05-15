using UnityEngine;
using TMPro;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winPanel;
    public AudioSource winSound;

    [Header("Stat Text Fields")]
    public TMP_Text lampsCollectedText;
    public TMP_Text obstaclesPassedText;

    public void ShowWinScreen(int lampsCollected, int obstaclesPassed)
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        if (winSound != null)
            winSound.Play();

        if (lampsCollectedText != null)
            lampsCollectedText.text = "Lamps Collected: " + lampsCollected;

        if (obstaclesPassedText != null)
            obstaclesPassedText.text = "Obstacles Passed: " + obstaclesPassed;
    }
}
