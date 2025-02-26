using UnityEngine;
using UnityEngine.UI;  // For UI components like Button

public class PlayButton : MonoBehaviour
{
    public Button playButton;  // Reference to the Play button
    private bool isGamePaused = true;  // To track whether the game is paused

    void Start()
    {
        // Initially freeze the game by setting Time.timeScale to 0
        Time.timeScale = 0f;

        // Make sure the button is assigned in the inspector
        if (playButton != null)
        {
            // Add a listener to the button to trigger the ResumeGame function when clicked
            playButton.onClick.AddListener(ResumeGame);
        }
    }

    // This method will be called when the button is clicked
    void ResumeGame()
    {
        if (isGamePaused)
        {
            // Unfreeze the game by setting Time.timeScale to 1
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}