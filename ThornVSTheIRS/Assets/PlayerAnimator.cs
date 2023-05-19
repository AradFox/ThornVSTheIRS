using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isWallJumping;

    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && IsGrounded() && !isWallJumping)
        {
            anim.Play("MoveRight");
        }
        if (Input.GetKeyDown(KeyCode.A) && IsGrounded() && !isWallJumping)
        {

            anim.Play("MoveLeft");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
