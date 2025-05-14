using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    // This is called from the UI buttons (Jasmine, Genie)
    public void SelectCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayerPrefs.Save(); 
        Debug.Log("Character selected: " + index);
    }
}
