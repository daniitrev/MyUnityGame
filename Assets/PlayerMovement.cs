using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       
    public float jumpForce = 12f;       
    public LayerMask groundLayer;       

    private Rigidbody2D rb;             
    private BoxCollider2D box;        
    private Animator animator;          

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        float moveInput = Input.GetAxisRaw("Horizontal");

        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

       
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x)); 

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
        }
    }

  
    bool IsGrounded()
    {
        return box.IsTouchingLayers(groundLayer); 
    }
}
