using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject modeSelectPanel;

    public void OnSelectModeClicked()
    {
        modeSelectPanel.SetActive(true);
    }

    public void OnEasyModeSelected()
    {
        GameModeManager.SelectedMode = GameMode.Easy;
        GameModeManager.ModeChosen = true;
        modeSelectPanel.SetActive(false);
    }

    public void OnHardModeSelected()
    {
        GameModeManager.SelectedMode = GameMode.Hard;
        GameModeManager.ModeChosen = true;
        modeSelectPanel.SetActive(false);
    }

    public void OnMissionModeSelected()
    {
        GameModeManager.SelectedMode = GameMode.Mission;
        GameModeManager.ModeChosen = true;
        modeSelectPanel.SetActive(false);
    }

    public void OnPlayClicked()
    {
        // If mode not chosen, default to Easy
        if (!GameModeManager.ModeChosen)
        {
            GameModeManager.SelectedMode = GameMode.Easy;
        }

        SceneManager.LoadScene("GameScene");
    }
}
