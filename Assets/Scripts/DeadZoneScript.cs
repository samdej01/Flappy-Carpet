using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get CarpetScript directly (no tag check)
        CarpetScript carpet = other.GetComponent<CarpetScript>();

        if (carpet != null)
        {
            carpet.ForceGameOver(); // Trigger the same game over logic
        }
    }
}
