using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingHeight = 16f;
    private bool isFacingRight = true;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
      horizontal = Input.GetAxisRaw("Horizontal");

      if (IsGrounded()){
        coyoteTimeCounter = coyoteTime;
      }
      else{
        coyoteTimeCounter -= Time.deltaTime;
      }

      if (Input.GetButtonDown("Jump")){
        jumpBufferCounter = jumpBufferTime;
      }
      else{
        jumpBufferCounter -= Time.deltaTime;
      }

      if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f){
        rb.velocity = new Vector2(rb.velocity.x, jumpingHeight);
        jumpBufferCounter = 0f;
      }

      if (Input.GetButtonDown("Jump") && IsGrounded())
      {
        rb.velocity = new Vector2(rb.velocity.x, jumpingHeight);
      }

      if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
      {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        coyoteTimeCounter = 0f;
      }

      Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
    

    private void Flip()
    {
        if ( isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
