using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FloatData speedData;

    private float timeElapsed = 0f;

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
}
