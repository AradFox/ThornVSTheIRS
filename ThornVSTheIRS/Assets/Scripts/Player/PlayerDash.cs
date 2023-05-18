using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using EZCameraShake;

public class PlayerDash: MonoBehaviour
{
    float horizontal;
    public float speed = 8f;
    public float jumpingPower = 10f;
    private bool isFacingRight = true;
   
    private bool doubleJump;

    private bool isWallSliding;
    private float wallSlideSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpDirection;
    private float wallJumpTime = 0.2f;
    private float wallJumpCounter;
    private float wallJumpDuration;
    private Vector2 wallJumpPower = new Vector2(8f, 16f);

    private bool canDash = true;
    private bool isDashing;
    private float dashPower = 24f;
    private float dashTime = 0.2f;
    private float dashCoolDown = .5f;

    public AudioClip jumpSound;
    public AudioClip dashSound;
    public AudioClip walkSound;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (!Input.GetKey(KeyCode.W) && IsGrounded())
        {
            doubleJump = false;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (IsGrounded() || doubleJump)
            {
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doubleJump = !doubleJump;
            }
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash && !isWallJumping)
        {
            StartCoroutine(Dash());
        }

        WallSlide();
        WallJump();
       

        if (!isWallJumping)
        {
            Flip();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        if (!isWallJumping && !isDashing)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        GetComponent<AudioSource>().PlayOneShot(dashSound);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;  
        }
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpCounter = wallJumpTime;

            CancelInvoke(nameof(StopWallJump));
        }
        if (Input.GetKeyDown(KeyCode.W) && wallJumpCounter > 0)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
            wallJumpCounter = 0f;

            if (transform.localScale.x != wallJumpDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJump), wallJumpDuration);
        }
    }

    private void StopWallJump()
    {
        isWallJumping = false;

    }
}
