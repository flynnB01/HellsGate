using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player; // drag player obj into inspector field
    private GameObject hitbox = default;
    private new PolygonCollider2D collider;
    private Animator anim;

    private float bossSize_x;
    private float bossSize_y;
    private float bossSize_z;

    public int hp = 100;
    public int exp = 75;
    public difficulty difficultyScript; // manages difficulty

    //public float moveSpeed;

    public bool isAttacking = false;
    private bool isAggroed = false;

    private float timerBetweenAtk = 0.0f;

    private float atkTimer = 0.0f;
    private float atkTimeDelay = 0.0f;

    private float flipTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        hitbox = transform.GetChild(0).gameObject; // get hitbox game object from boss' arm
        collider = hitbox.GetComponent<PolygonCollider2D>(); // get collider from hitbox obj

        anim = transform.GetChild(0).gameObject.GetComponent<Animator>(); // get animator for boss' arm

        // declare boss size variables using localScale
        bossSize_x = transform.localScale.x;
        bossSize_y = transform.localScale.y;
        bossSize_z = transform.localScale.z;

    }

    // Update is called once per frame
    void Update()
    {
        float aggroDistance = 20.0f; // distance where boss will see player

        // check whether the player is in front or behind
        if((transform.position.x - player.position.x) > 0) // player in front >0, player behind <0
        {
            transform.localScale = new Vector3(bossSize_x * 1, bossSize_y, bossSize_z); // facing left
        }
        else
        {
            transform.localScale = new Vector3(bossSize_x * -1, bossSize_y, bossSize_z); // facing right
        }

        // if player character is in sight of boss, will start attacking
        if (isAggroed) // if player has boss aggro
        {
            if (Vector2.Distance(transform.position, player.position) > aggroDistance) // if player is out of aggro distance
            {
                isAggroed = false;

                anim.SetBool("isAggroed", false); // set aggro state in animator to false
            }
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
            if (Vector2.Distance(transform.position, player.position) < aggroDistance)
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

    public void takeDmg(int damage)
    {
        if (difficultyScript.isEasy)
        {
            damage = (int)(damage * 1.3f);
        }

        if (difficultyScript.isHard)
        {
            damage = (int)(damage * 0.6f);
        }

        Debug.Log("Boss taken damage");

        hp -= damage;

        if (hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
       
       if(expManager.Instance)
        {
            expManager.Instance.AddExp(exp);
        }
        Destroy(gameObject);
        Debug.Log("Boss Defeated");
    }
}
