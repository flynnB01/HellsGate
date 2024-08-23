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
    public bool grounded;
    public bool doubleJump;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");

        // Move the player horizontally
        if (Mathf.Abs(xinput) > 0)
        {
            body.velocity = new Vector2(xinput * moveSpeed, body.velocity.y);
        }

        // Jumping logic
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                // First jump
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                grounded = false; // Player is no longer on the ground
                doubleJump = true; // Enable double jump
            }
            else if (doubleJump)
            {     //!grounded && 
                // Double jump
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                doubleJump = false; // Disable double jump after it's used
            }
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
    }

    void CheckGround()
    {
        // Check if the player is on the ground
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
}
