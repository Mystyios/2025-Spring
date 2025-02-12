using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    // This method is called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Destroy the object that entered the trigger
        Destroy(other.gameObject);
    }
}