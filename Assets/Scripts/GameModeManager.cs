public enum GameMode
{
    Easy,
    Hard,
    Mission
}

public static class GameModeManager
{
    public static GameMode SelectedMode { get; set; } = GameMode.Easy;
    public static bool ModeChosen { get; set; } = false;
}
