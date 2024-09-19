using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Animator ani;
    public GameObject atkPos;//attack start spot
    bool isAtk;//check able to attack
    public GameObject[] Weapons;//weapon lists

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();//play attack animation
        ChageWeapon(1);//weapon change
      
        isAtk = true;
    }

    public void ChageWeapon(float id)
    {
        ani.SetFloat("weapon 0", id);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAtk) // check if attack
        {
            Debug.Log("Attack");
            Attack(); // invoke attack
        }
    }

   

    void Attack()//attack 
    {
        //play attack animation
        ani.SetFloat("attack", 1);
        //attack box visible when attack
        atkPos.SetActive(true);
        isAtk = false;
        //cd for attack
        StartCoroutine(WaitAtk());
        
    }
    IEnumerator WaitAtk()//time wait for next attack
    {
        yield return new WaitForSeconds(0.5f);
        atkPos.SetActive(false);
        ani.SetFloat("attack", 0);
        isAtk = true;
    }






}
