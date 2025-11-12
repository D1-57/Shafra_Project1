using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Player Settings")]
    public int PlayerHealth = 3;
    public int key = 0;

    [Header("UI Screens")]
    public GameObject DeathScreen;
    public GameObject WinScreen;
    public GameObject PauseScreen;
    public GameObject SettingScreen;

    [Header("Door Settings")]
    public Animator DoorAnim;
    public int DoorIntValue = 0; // Integer value to send to Animator when opening

    private bool isPaused = false;

    void Start()
    {
                      

        if (PauseScreen != null)
            PauseScreen.SetActive(false);
    }

    void Update()
    {
        // Pause/Resume when pressing ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Key pickup
        if (collision.gameObject.CompareTag("Key"))
        {
            DoorIntValue++;
            Destroy(collision.gameObject);
        }

        // Door interaction using Animator int parameter
        if ( DoorIntValue > 0)
        {
            if (DoorAnim != null)
            {
                DoorAnim.SetInteger("Door", DoorIntValue);
                Debug.Log("Door animation triggered with int = " + DoorIntValue);
            }
        }
    }

    // Pause toggle
    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        if (PauseScreen != null)
            PauseScreen.SetActive(true);

        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (PauseScreen != null)
            PauseScreen.SetActive(false);

        Debug.Log("Game Resumed");
    }
}
