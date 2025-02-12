using UnityEngine;

public class HeartUIManager : MonoBehaviour
{
    public IntData playerHealth;  // Reference to the PlayerHealthData ScriptableObject
    public GameObject[] heartImages;       // Array of heart Image objects

    void Start()
    {
        UpdateHeartUI();
    }

    // Update the heart UI based on current health
    public void UpdateHeartUI()
    {
        // Loop through all heart images
        for (int i = 0; i < heartImages.Length; i++)
        {
            // If the current heart's index is less than the current health, set it active (visible)
            heartImages[i].SetActive(i < playerHealth.Value);
        }
    }
}