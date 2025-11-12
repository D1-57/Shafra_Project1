using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Check if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    // Play button: loads the main gameplay scene
    public void PlayGame()
    {
        // Replace "GameScene" with your actual gameplay scene name
        SceneManager.LoadScene("Level1");
    }

    // Exit button: quits the application
    public void ExitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

    // Pause button or ESC key: toggles pause/resume
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Resume
            isPaused = false;
            Debug.Log("Game Resumed");
        }
        else
        {
            Time.timeScale = 0f; // Pause
            isPaused = true;
            Debug.Log("Game Paused");
        }
    }

    // Go back button: loads the main menu scene
    public void GoBackToMainMenu()
    {
        // Ensure game resumes speed before loading
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
