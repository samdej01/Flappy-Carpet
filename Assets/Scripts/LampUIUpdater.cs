using UnityEngine;
using TMPro;

public class LampUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI lampCountText;

    void Start()
    {
        int savedLamps = PlayerPrefs.GetInt("TotalLamps", 0);
        lampCountText.text = "Lamps Collected: " + savedLamps;
    }
}
