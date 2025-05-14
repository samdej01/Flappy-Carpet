using UnityEngine;

public class LampManager : MonoBehaviour
{
    public static LampManager Instance;
    public int totalLampsCollected = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Load saved lamp count
        totalLampsCollected = PlayerPrefs.GetInt("TotalLamps", 0);
    }

    public void CollectLamp(GameObject lamp)
    {
        Destroy(lamp);
        totalLampsCollected++;
        PlayerPrefs.SetInt("TotalLamps", totalLampsCollected);
        PlayerPrefs.Save();
        Debug.Log("Lamp collected! Total: " + totalLampsCollected);
    }
}
