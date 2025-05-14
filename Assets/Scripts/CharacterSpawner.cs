using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs; // [0] = Jasmine, [1] = Genie
    public Transform spawnPoint;

    void Start()
    {
        int selected = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Debug.Log("SelectedCharacter Index: " + selected);

        if (characterPrefabs == null || characterPrefabs.Length == 0)
        {
            Debug.LogError("Character prefabs array is empty!");
            return;
        }

        if (selected >= 0 && selected < characterPrefabs.Length)
        {
            GameObject character = Instantiate(characterPrefabs[selected], spawnPoint.position, Quaternion.identity);
            Debug.Log("Spawned character: " + character.name);
        }
        else
        {
            Debug.LogWarning("Selected character index out of range: " + selected);
        }
    }
}
