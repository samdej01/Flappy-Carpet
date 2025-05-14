using UnityEngine;

public class LampCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Lamp collected"); 
            LampManager.Instance.CollectLamp(gameObject);
        }
    }
}
