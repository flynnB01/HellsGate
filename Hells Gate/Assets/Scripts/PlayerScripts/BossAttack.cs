using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform player;
    private GameObject hitbox = default;
    private new PolygonCollider2D collider;
    private Animator anim;

    public float moveSpeed;

    public bool isAttacking = false;
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
        // if player character is in sight of boss, will start attacking
        
        if (isAggroed) // if player has boss aggro
        {
            if (!isAttacking) // makes sure boss cant attack while already attacking
            {
                timerBetweenAtk += Time.deltaTime;

                if (timerBetweenAtk >= 5.0f)
                {
                    //Debug.Log("Boss Attacking");
                    timerBetweenAtk = 0.0f;

                    Attack();
                }
            }
            else // when monster is attacking
            {

                if (atkTimeDelay >= 0.8f) // delay is finished
                {

                    atkTimer += Time.deltaTime; // count time hitbox is up
                    //Debug.Log(atkTimer);
                    collider.enabled = true;

                    if (atkTimer >= 0.2f)
                    {
                        Debug.Log("Boss Attack Finished");

                        atkTimer = 0.0f; // reset timer
                        atkTimeDelay = 0.0f; // reset delay

                        isAttacking = false;
                        anim.SetBool("isAttacking", false);
                        //hitbox.SetActive(false);
                        collider.enabled = false;

                    }
                }
                else // start delay
                {
                  //Debug.Log(atkTimeDelay);

                    atkTimeDelay += Time.deltaTime;
                }


            }


        } else
        {
            if (Vector2.Distance(transform.position, player.position) < 10.0)
            {
                isAggroed = true;

                anim.SetBool("isAggroed", true);
            }
        }
        
    }

    public void Attack()
    {
        Debug.Log("Boss Attack");
        isAttacking = true;
        anim.SetBool("isAttacking", true);


    }

}
