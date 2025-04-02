using UnityEngine;
using TMPro;
using System.Collections;  // Required for coroutines

public class ScoreUpdater : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;
    
    private float updateInterval = 0.1f;  // The time interval to update the score

    void Start()
    {
        // Start the coroutine when the game starts
        StartCoroutine(ScoreUpdateCoroutine());
    }

    // The coroutine that updates the score every 'updateInterval' seconds
    private IEnumerator ScoreUpdateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);  // Wait for the specified interval

            score += 1.0f;  // Increase the score by 1
            scoreText.text = score.ToString();  // Update the UI text
        }
    }
}