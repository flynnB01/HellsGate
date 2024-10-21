using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // scale for flipping sprite
    private float enemySize_x;
    private float enemySize_y;
    private float enemySize_z;

    // patrolling variables
    public Transform[] patrolPoints; // array of points which dictate where an enemy can patrol from
    public float moveSpeed;
    public int patrolDest;

    // chasing variables
    public Transform playerTransform;
    public bool isChasing;
    public float detectDistance;

    public float aggroTimer;
    private float aggroTimerTemp;

    private void Start()
    {
         enemySize_x = transform.localScale.x; // gets scale for x to flip sprite
         enemySize_y = transform.localScale.y; // gets scale for x to flip sprite
         enemySize_z = transform.localScale.z; // gets scale for x to flip sprite
    }
    // Update is called once per frame
    void Update()
    {
        // when enemy is chasing player
        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                Debug.Log("Left");
                transform.localScale = new Vector3(enemySize_x * 1, enemySize_y, enemySize_z); // facing left
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                Debug.Log("Right");

                transform.localScale = new Vector3(enemySize_x * -1, enemySize_y, enemySize_z); // facing right


                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }

            aggroTimer -= 1.0f * Time.deltaTime;
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
            // keeps original aggro timer value for when the value needs to be reset
            aggroTimerTemp = aggroTimer;

            // if player character is in sight of enemy, will start chasing player
            if (Vector2.Distance(transform.position, playerTransform.position) < detectDistance)
            {
                isChasing = true;
                // make enemy faster while chasing player
                moveSpeed = moveSpeed * 4.0f;
            }

            // makes enemy move from its current position to the destination position
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDest].position, moveSpeed * Time.deltaTime);

            // if enemy gets close to patrol point, send back to other patrol point dest
            if (Vector2.Distance(transform.position, patrolPoints[patrolDest].position) < 0.2f)
            {
                // changes direction
                patrolDest = patrolDest ^ 1; // swaps

                if (patrolDest == 0) // going to left patrol point
                {
                    transform.localScale = new Vector3(enemySize_x * 1, enemySize_y, enemySize_z); // facing left

                } else // going to right patrol point
                {
                    transform.localScale = new Vector3(enemySize_x * -1, enemySize_y, enemySize_z); // facing left

                }
            }
        }
    }
}
