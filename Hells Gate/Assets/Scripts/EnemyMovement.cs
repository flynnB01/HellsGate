using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb; // this obj's rigidbody

    // scale for flipping sprite
    private float enemySize_x;
    private float enemySize_y;
    private float enemySize_z;

    // patrolling variables
    public float moveSpeed;
    private float patrolDest;

    // chasing variables
    public Transform playerTransform;
    private bool isChasing;
    public float detectDistance;

    // movement and jump conditions
    private BoxCollider2D wallCheck; // checks for wall to try jump
    private BoxCollider2D groundCheck; // checks for wall to try jump
    public LayerMask wallMask; //layer mask, set to "ground"
    private bool canJump = true;

    //  times how long enemy is aggroed toward player
    public float aggroTimer;
    private float aggroTimerTemp;


    public float patrolTimer = 5.0f; // timer which counts down when enemy will flip and turn around

    private void Start()
    {
        enemySize_x = transform.localScale.x; // gets scale for x to flip sprite
        enemySize_y = transform.localScale.y; // gets scale for x to flip sprite
        enemySize_z = transform.localScale.z; // gets scale for x to flip sprite

        patrolDest = 1.0f; // enemy going left

        wallCheck = transform.GetChild(0).GetComponent<BoxCollider2D>(); // get collider from wall check child
        groundCheck = transform.GetChild(1).GetComponent<BoxCollider2D>(); // get collider from ground check child

        rb = GetComponent<Rigidbody2D>(); // get this object's rigidbody to allow jumping
    }
    // Update is called once per frame
    void Update()
    {
        // enemy can jump anytime
        if (Physics2D.OverlapAreaAll(wallCheck.bounds.min, wallCheck.bounds.max, wallMask).Length > 0 && canJump == true) // if wall check detects a wall and that enemy is not already jumping
        {
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }

        if (rb.velocity.y == 0) // enemy can only jump again once it has hit the ground (velocity y = 0)
        {
            canJump = true;
        }

        // when enemy is chasing player
        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                //Debug.Log("Left");
                transform.localScale = new Vector3(enemySize_x * 1, enemySize_y, enemySize_z); // facing left
                rb.velocity = new Vector2(moveSpeed * -1, rb.velocity.y);
            }
            if (transform.position.x < playerTransform.position.x)
            {
                //Debug.Log("Right");

                transform.localScale = new Vector3(enemySize_x * -1, enemySize_y, enemySize_z); // facing right


                rb.velocity = new Vector2(moveSpeed * 1, rb.velocity.y);
            }




            aggroTimer -= Time.deltaTime;
            if (aggroTimer < 0.0f)
            {
                Debug.Log("lost interest");

                // reset to normal patrolling state
                moveSpeed = moveSpeed / 4.0f;
                isChasing = false;
                aggroTimer = aggroTimerTemp;
            }
        }
        else // enemy is patrolling
        {
            // if ground check detects a cliff (absence of ground)
            if (!(Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, wallMask).Length > 0))
            {
                // turn around enemy to avoid falling off cliff
                patrolDest *= -1;
                patrolTimer = 5.0f;

            }
            // keeps original aggro timer value for when the value needs to be reset
            aggroTimerTemp = aggroTimer;

            patrolTimer -= Time.deltaTime; // decrement patrol timer

            // if player character is in sight of enemy, will start chasing player
            if (Vector2.Distance(transform.position, playerTransform.position) < detectDistance)
            {
                isChasing = true;
                // make enemy faster while chasing player
                moveSpeed = moveSpeed * 4.0f;
            }

            if (patrolTimer <= 0)
            {
                patrolDest *= -1.0f; // swaps direction once timer is 0
                patrolTimer = 5.0f; // resets timer

            }

            // patrolling
            transform.localScale = new Vector3(enemySize_x * -patrolDest, enemySize_y, enemySize_z); // facing left
            rb.velocity = new Vector2(moveSpeed * patrolDest, rb.velocity.y);

            //Debug.Log(enemySize_x * patrolDest);
            //Debug.Log(patrolDest);
        }
    }
}