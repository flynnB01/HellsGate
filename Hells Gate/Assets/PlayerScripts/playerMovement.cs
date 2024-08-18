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


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");

        if (Mathf.Abs(xinput) > 0)
        {
            body.velocity = new Vector2(xinput * moveSpeed, body.velocity.y);
        }

        if (Mathf.Abs(yinput) > 0 && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, yinput * jumpSpeed);
        }
    }

    void FixedUpdate()
    {
        CheckGround();

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
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
}


