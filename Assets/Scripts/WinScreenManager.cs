using UnityEngine;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winPanel;
    public AudioSource winSound;

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);           // Show win screen UI
        if (winSound != null)
        {
            winSound.Play();               // Play win sound
        }
    }
}
