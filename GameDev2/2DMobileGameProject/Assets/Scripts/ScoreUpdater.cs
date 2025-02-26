using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public float score;  // Reference to the Score ScriptableObject
    public TextMeshProUGUI scoreText;
    private float timeElapsed = 0f;  // Tracks elapsed time

    void Update()
    {
        // Update timeElapsed by the time passed since the last frame
        timeElapsed += Time.deltaTime;

        // If 0.1 seconds have passed, increase the score by 1
        if (timeElapsed >= 0.1f)
        {
            score += 1.0f;  // Increase the score by 1
            scoreText.text = score.ToString();
            timeElapsed = 0f;  // Reset the timer
        }
    }
}