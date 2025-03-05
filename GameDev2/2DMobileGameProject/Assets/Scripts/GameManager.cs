using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FloatData speedData;

    private float timeElapsed = 0f;
    private bool isGamePaused = true;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timeElapsed by the time passed since the last frame
        timeElapsed += Time.deltaTime;

        // If 0.1 seconds have passed, increase the score by 1
        if (timeElapsed >= 1f)
        {
            speedData.Value += 0.1f;  // Increase the score by 1
            timeElapsed = 0f;  // Reset the timer
        }
    }
    
    public void ResumeGame()
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
