using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float velocity;
    public float MoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {
         velocity = Input.GetAxisRaw("Horizontal");
        if (velocity != 0)
            GetComponent<SpriteRenderer>().flipX = velocity > 0;
        anim.SetFloat("Velocity", Mathf.Abs(velocity));
        rb.linearVelocity = new Vector2(velocity*MoveSpeed*Time.deltaTime, 0);
    }
}
