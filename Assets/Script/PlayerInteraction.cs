using UnityEngine;
using TMPro;          

public class PlayerInteraction : MonoBehaviour
{
    public AudioManager ad;
    [Header("Player Settings")]
    public int PlayerHealth = 3;
    private Vector2 startPosition; // first location to restart from

    [Header("Hearts UI")]
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public TMP_Text keyTMP;

    [Header("UI Screens")]
    public GameObject DeathScreen;
    public GameObject WinScreen;
    public GameObject PauseScreen;
    public GameObject SettingScreen;

    [Header("Door Settings")]
    public Animator DoorAnim;
    public int Key;
    public int RequiredKeys = 3; // number of keys needed to unlock door

    private bool isPaused = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // save starting point

        if (PauseScreen != null)
            PauseScreen.SetActive(false);

        if (WinScreen != null)
            WinScreen.SetActive(false);

        if (DeathScreen != null)
            DeathScreen.SetActive(false);

        UpdateKeyUI();
    }

    void Update()
    {
        UpdateHearts();

        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    void UpdateHearts()
    {
        // update heart visibility
        Heart1.SetActive(PlayerHealth >= 1);
        Heart2.SetActive(PlayerHealth >= 2);
        Heart3.SetActive(PlayerHealth >= 3);

        // death condition
        if (PlayerHealth <= 0)
        {
            if (DeathScreen != null)
                DeathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // --- Pick up key ---
        if (collision.gameObject.CompareTag("Key"))
        {
            Key++;
            ad.keys();
            Destroy(collision.gameObject);

            if (DoorAnim != null)
            {
                DoorAnim.SetInteger("Key", Key);
                Debug.Log("Door animation triggered with int = " + Key);
            }

            UpdateKeyUI();
        }

        // --- Enter door (win condition) ---
        if (collision.gameObject.CompareTag("Door"))
        {
            if (Key >= RequiredKeys)
            {
                if (WinScreen != null)
                {
                    WinScreen.SetActive(true);

                    Time.timeScale = 0f; // stop the game
                }
                Debug.Log("Player entered door! You Win!");
            }
            else
            {
                Debug.Log("Door is locked. Need more keys!");
            }
        }

        // --- If hit by enemy ---
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHit();
            ad.Damge();
        }
    }

    void PlayerHit()
    {
        PlayerHealth--;

        if (PlayerHealth > 0)
        {
            // Move player back to starting position
            transform.position = startPosition;
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Player hit! Returned to start position.");
        }
        else
        {
            Debug.Log("Player died!");
        }
    }

   void UpdateKeyUI()
    { 
        if (keyTMP != null) keyTMP.text = ": " + Key+ "/3 ";
        
     }
    // --- Pause controls ---
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
