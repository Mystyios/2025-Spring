using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string GameScene;
    public void StartGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
