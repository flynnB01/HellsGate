using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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


    // Update is called once per frame
    void Update()
    {
        // when enemy is chasing player
        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                //transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                //transform.localScale = new Vector3(-1, 1, 1);
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
                //transform.localScale = new Vector3(1, 1, 1);
                patrolDest = patrolDest ^ 1; // swaps
            }
        }
    }
}
