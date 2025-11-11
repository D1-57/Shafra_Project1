using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenueCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }
    public void Stop()
    {
        
        PauseMenueCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void Play()
    {
        PauseMenueCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
