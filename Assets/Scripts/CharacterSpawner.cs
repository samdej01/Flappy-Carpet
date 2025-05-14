using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Jasmine = 0, Genie = 1
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

        if (selected < characterPrefabs.Length)
        {
            GameObject spawned = Instantiate(characterPrefabs[selected], spawnPoint.position, Quaternion.identity);
            Debug.Log("Spawned character: " + spawned.name);
        }
        else
        {
            Debug.LogWarning("Selected character index out of range.");
        }
    }
}
