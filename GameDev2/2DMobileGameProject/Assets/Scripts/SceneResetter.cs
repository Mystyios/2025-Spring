using UnityEngine;
using UnityEngine.SceneManagement; // Make sure to include this to handle scene management

public class SceneResetter : MonoBehaviour
{
    // This method will be called when the button is pressed
    public void ResetScene()
    {
        // Get the name of the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}