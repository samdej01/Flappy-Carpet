using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void OnPlayPressed()
    {
        // Load game scene after selecting mode
        SceneManager.LoadScene("GameScene");
    }

    public void OnSelectModePressed()
    {
        // Load a separate mode selection scene or open a UI panel
        SceneManager.LoadScene("ModeSelectionScene");
    }

    public void OnShopPressed()
    {
        // Load shop scene or show character selector UI
        SceneManager.LoadScene("ShopScene");
    }
}
