using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    [HideInInspector] public float moveSpeed;
    [HideInInspector] public float jumpSpeed;
    [Range(0f, 1f)]
    public float groundDecay;
    [Range(0f, 1f)]
    public float airDecay;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    private bool grounded; // checks if player has touched the ground
    private bool doubleJump;
    private bool hasJumped;
    private bool readyToLand; // makes sure landing sound effect does not loop when touching the ground

    public Animator animator;
    private character characterScript;
    public new SFXPlayer audio;

    public DashBar dashBar;

    // Dash Variables
    public float dashSpeedMultiplier = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool canDash = true;
    private bool isDashing;
    private float dashEndTime = 0f;
    private float lastDashTime = -100f;
    public bool canMove = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        characterScript = GetComponent<character>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // get speeds defined in character
        moveSpeed = characterScript.moveSpeed;
        jumpSpeed = characterScript.jumpSpeed;


        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");

        //Debug.Log(xinput);

        if (!canDash)
        {
            float remainingCooldown = lastDashTime + dashCooldown - Time.time;
            dashBar.SetCooldown(Mathf.Clamp(remainingCooldown, 0, dashCooldown));
            dashBar.gameObject.SetActive(true);
        }

        if (canDash)
        {
            dashBar.gameObject.SetActive(false);
        }

        // Move the player horizontally
        if (Mathf.Abs(xinput) > 0 && !isDashing && canMove)
        {
            //Debug.Log("Move");

            transform.localScale = new Vector3(xinput, 1, 1); // flip character
            body.velocity = new Vector2(xinput * moveSpeed, body.velocity.y);
            //Debug.Log(body.velocity);
        }

        // Dash mechanic
        if (Input.GetButtonDown("Dash") && canDash && canMove)
        {
            Debug.Log("Dash");

            StartDash(xinput);
        }

        //ends dash
        if (isDashing && Time.time >= dashEndTime)
        {
            EndDash();
        }

        // Jumping logic
        if (Input.GetButtonDown("Jump") && canMove)
        {
            Debug.Log("Jump");

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
            //deathMovement(); // Player stops moving when dead
            Time.timeScale = 0; //changed so player cant change directions in deathMenu and can easily respawn
        }

        CheckGround(); // check if player is touching the ground

        // Deceleration/drag logic
        if (grounded)
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                body.velocity = new Vector2(body.velocity.x * groundDecay, body.velocity.y);
            }
            animator.SetBool("isJumping", false); // falling animation stops
            if (readyToLand)
            {
                Debug.Log("Landed");
                audio.PlaySFX(audio.sfx03); // play landing audio
                readyToLand = false; // prevents sound from being looped

            }
        }
        else
        {
            readyToLand = true;
            if (Input.GetAxis("Horizontal") == 0)
            {
                body.velocity = new Vector2(body.velocity.x * airDecay, body.velocity.y);
            }
        }


        animator.SetFloat("x_vel", Mathf.Abs(body.velocity.x));
        animator.SetFloat("y_vel", body.velocity.y);
    }

    void CheckGround()
    {
        // Check if the player is on the ground
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        if (grounded)
        {
            hasJumped = false;
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

        animator.SetBool("isJumping", true); // jump animation frame
        audio.PlaySFX(audio.sfx02); // play jump audio
    }


    void deathMovement()
    {
        moveSpeed = 0;
        body.velocity = Vector2.zero;
    }

    public void enableMovement()
    {
    canMove = true;
    }

    public void disableMovement()
    {
    canMove = false;
    }
}
