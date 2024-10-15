using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform player;
    private GameObject hitbox = default;
    PolygonCollider2D collider;
    private Animator anim;

    public float moveSpeed;

    private bool isAttacking = false;
    private bool isAggroed = false;

    private float timerBetweenAtk = 0.0f;

    private float atkTimer = 0.0f;
    private float atkTimeDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = transform.GetChild(0).gameObject;
        collider = hitbox.GetComponent<PolygonCollider2D>();

        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player character is in sight of boss, will start chasing player
        
        if (isAggroed) // if player has boss aggro
        {
            //if (transform.position.x > player.position.x)
            //{
            //    //transform.localScale = new Vector3(1, 1, 1);
            //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            //}
            //if (transform.position.x < player.position.x)
            //{
            //    //transform.localScale = new Vector3(-1, 1, 1);
            //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            //}
            if(!isAttacking) // makes sure boss cant attack while already attacking
            {
                timerBetweenAtk += Time.deltaTime;

                if (timerBetweenAtk >= 5.0f)
                {
                    Debug.Log("Boss Attacking");
                    Attack();
                }
            }
            

        } else
        {
            if (Vector2.Distance(transform.position, player.position) < 10.0)
            {
                isAggroed = true;

                anim.SetBool("isAggroed", true);
                // make enemy faster while chasing player
                //moveSpeed *= 1.2f;
            }
        }
//Debug.Log(Time.deltaTime);
        if (isAttacking)
        {
            
            if(atkTimeDelay >= 0.7f) // delay is finished
            {

                atkTimer += Time.deltaTime; // count time hitbox is up
                Debug.Log(atkTimer);
                collider.enabled = true;

                if (atkTimer >= 0.3f)
                {
                    Debug.Log("Boss Attack Finished");

                    atkTimer = 0.0f; // reset timer
                    atkTimeDelay = 0.0f; // reset delay
                    timerBetweenAtk = 0.0f;

                    isAttacking = false;
                    anim.SetBool("isAttacking", false);
                    //hitbox.SetActive(false);
                    collider.enabled = false;

                }
            }
            else  
            { // increment delay
                //Debug.Log(atkTimeDelay);

                atkTimeDelay += Time.deltaTime;
            }

            
        }
    }

    public void Attack()
    {
        Debug.Log("Boss Attacking 2");
        isAttacking = true;
        anim.SetBool("isAttacking", true);


    }

}
