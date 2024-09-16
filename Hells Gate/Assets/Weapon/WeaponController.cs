using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Animator ani;
    
    public GameObject[] Weapons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChageWeapon(int id)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // check if attack
        {
            Attack(); // invoke attack
        }
    }

    void Attack()//attack 
    {
        //play attack animation
        ani.SetBool("atk",true);
        //cd for attack
        StartCoroutine(WaitAtk());
        
    }
    IEnumerator WaitAtk()
    {
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("atk", false);
    }






}
