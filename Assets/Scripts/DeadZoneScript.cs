using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CarpetScript carpet = other.GetComponent<CarpetScript>();
            if (carpet != null)
            {
                carpet.ForceGameOver(); // Calls the same method as a collision
            }
        }
    }
}
