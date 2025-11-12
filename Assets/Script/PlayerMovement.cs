using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioManager ad;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float MoveSpeed = 5f;
    public float JumpForce = 7f;
    private float velocity;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    

    void Update()
    {
        velocity = Input.GetAxisRaw("Horizontal");

        // Flip sprite
        if (velocity != 0)
            sr.flipX = velocity > 0;

        anim.SetFloat("Velocity", Mathf.Abs(velocity));
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            ad.JumpSound();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocity * MoveSpeed, rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce); 
    }

    void OnDrawGizmosSelected()
    {
        // Draw ground check circle in editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
