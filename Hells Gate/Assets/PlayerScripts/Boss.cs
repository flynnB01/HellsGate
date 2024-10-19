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

    public int hp = 100;
    public int exp = 75;
    public difficulty difficultyScript; // manages difficulty

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
        float aggroDistance = 20.0f; // distance where boss will see player

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
