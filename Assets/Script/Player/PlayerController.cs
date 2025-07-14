using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Transform GroundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 moveInput;
    private bool jumpPressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 좌우 이동 입력
        moveInput.x = Input.GetAxisRaw("Horizontal");

        // 점프 입력
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }

        // 애니메이션 처리
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        animator.SetBool("IsGrounded", IsGrounded()); // 추가

        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
            bool isVerticalNearlyZero = Mathf.Abs(rb.linearVelocity.y) < 0.05f;
            animator.SetBool("IsVerticalZero", isVerticalNearlyZero);
        }

        // 방향 전환
        if (moveInput.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void FixedUpdate()
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

            if (jumpPressed && IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpPressed = false;
            }
            else
            {
                jumpPressed = false;
            }
        }
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, groundLayer);
        return grounded;
    }
}
