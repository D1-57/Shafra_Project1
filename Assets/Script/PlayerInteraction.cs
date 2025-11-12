using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Player Settings")]
    public int PlayerHealth = 3; // Start with 3 hearts

    [Header("Hearts UI")]
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    [Header("UI Screens")]
    public GameObject DeathScreen;
    public GameObject WinScreen;
    public GameObject PauseScreen;
    public GameObject SettingScreen;

    [Header("Door Settings")]
    public Animator DoorAnim;
    public int DoorIntValue = 0; // Integer value for Animator parameter

    private bool isPaused = false;

    void Start()
    {
        if (PauseScreen != null)
            PauseScreen.SetActive(false);
    }

    void Update()
    {
        // Update hearts based on health
        switch (PlayerHealth)
        {
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;

            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                break;

            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;

            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);

                if (DeathScreen != null)
                    DeathScreen.SetActive(true);

                Time.timeScale = 0f; // Stop game when player dies
                break;
        }

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

            // Open door when player gets a key
            if (DoorAnim != null)
            {
                DoorAnim.SetInteger("Door", DoorIntValue);
                Debug.Log("Door animation triggered with int = " + DoorIntValue);
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth--;
        }
    }

    // Toggle Pause/Resume
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
