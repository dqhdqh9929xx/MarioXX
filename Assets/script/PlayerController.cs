using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private Animator animator;
    private bool isGrounded;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimator();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimator()
    {
        bool IsRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool Isjumping = !isGrounded;
        animator.SetBool("IsRun", IsRunning);
        animator.SetBool("IsJumping", Isjumping);
    }
}
