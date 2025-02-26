using UnityEngine;
using UnityEngine.UI; // Make sure to include this for UI components

public class PauseGame : MonoBehaviour
{
    public Button pauseButton;  // Reference to the Pause Button UI
    public GameObject pauseMenu;  // Reference to the Pause Menu UI (optional)

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause button has a listener attached to it
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(TogglePause);
        }
        
        // Optional: If you have a pause menu, make sure it's hidden at the start
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            // Resume the game
            Time.timeScale = 1f; // Time flows normally
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(false); // Hide the pause menu
            }
        }
        else
        {
            // Pause the game
            Time.timeScale = 0f; // Freeze time
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(true); // Show the pause menu
            }
        }
        
        // Toggle the paused state
        isPaused = !isPaused;
    }
}