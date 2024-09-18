using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    public Rigidbody2D body;
    public float moveSpeed;
    public float jumpSpeed;
    [Range(0f, 1f)]
    public float groundDecay;
    [Range(0f, 1f)]
    public float airDecay;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    private bool grounded;
    private bool doubleJump;
    private bool hasJumped;

    private character characterScript;
    public Animator animator;

    // Dash Variables
    public float dashSpeedMultiplier = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool canDash = true;
    private bool isDashing;
    private float dashEndTime = 0f;
    private float lastDashTime = -100f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        characterScript = GetComponent<character>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");

        // Move the player horizontally
        if (Mathf.Abs(xinput) > 0 && !isDashing)
        {
            //Debug.Log(xinput);
            transform.localScale = new Vector3(xinput * 4.5f, 4.5f, 1.0f);
            body.velocity = new Vector2(xinput * moveSpeed, body.velocity.y);
        }

        // Dash mechanic
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartDash(xinput);
        }

        //ends dash
        if (isDashing && Time.time >= dashEndTime)
        {
            EndDash();
        }

        // Jumping logic
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                // First jump
                jump();
                grounded = false; // Player is no longer on the ground
                doubleJump = true; // Enable double jump
            }
            else if (doubleJump)
            {
                // Double jump
                jump();
                doubleJump = false; // Disable double jump after it's used
            }
            if (body.velocity.y < 0 && !hasJumped)
            {
                jump();
                doubleJump = false;
            }
        }

        if (characterScript.isDead == true)
        {
            deathMovement(); // Player stops moving when dead
        }
    }

    void FixedUpdate()
    {
        CheckGround();

        // Deceleration/drag logic
        if (grounded)
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                body.velocity = new Vector2(body.velocity.x * groundDecay, body.velocity.y);
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                body.velocity = new Vector2(body.velocity.x * airDecay, body.velocity.y);
            }
        }

        animator.SetFloat("X_Velocity", Mathf.Abs(body.velocity.x));
        animator.SetFloat("Y_Velocity", body.velocity.y);
    }

    void CheckGround()
    {
        // Check if the player is on the ground
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        if (grounded)
        {
            hasJumped = false;
            animator.SetBool("isJumping", hasJumped);


        }
        // Reset dash when grounded after dash cooldown
        if (grounded && !isDashing && Time.time >= lastDashTime + dashCooldown)
        {
            canDash = true;
        }
    }

    void StartDash(float xinput)
    {
        isDashing = true;
        canDash = false;
        lastDashTime = Time.time;
        dashEndTime = Time.time + dashDuration;
        //dash speed
        body.velocity = new Vector2(xinput * moveSpeed * dashSpeedMultiplier, body.velocity.y);
    }

    void EndDash()
    {
        // Stop the dash
        isDashing = false;
        body.velocity = new Vector2(0, body.velocity.y);
    }

    void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        hasJumped = true;

        animator.SetBool("isJumping", hasJumped);

    }

    void deathMovement()
    {
        moveSpeed = 0;
        body.velocity = Vector2.zero;
    }
}
