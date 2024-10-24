using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon
{
    public int id;
    public string name;
    public float damage;
    public int style;
    public GameObject bullets;
}

public class WeaponController : MonoBehaviour
{
    public Animator ani;
    public GameObject atkPos;//attack start spot
    bool isAtk;//check able to attack
    public Weapon[] weapons;
    Weapon nowWeapon;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        //ChageWeapon(1);//weapon change
      
        isAtk = true;
        InitWeapon();
    }

    public void InitWeapon()//initweapon set to sword
    {
        nowWeapon = weapons[0];
        atkPos.GetComponent<PlayerAttack>().SetWeaponDamage(weapons[0].damage);
        ani.SetFloat("weapon 0", 0);
    }

    public void ChageWeapon(int id) //weapon change's function
    {
        nowWeapon = weapons[id - 1];
        ani.SetInteger("weapon", nowWeapon.id);
        Debug.Log(nowWeapon.id);
        atkPos.GetComponent<PlayerAttack>().SetWeaponDamage(weapons[id-1].damage);
       //weapon change
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAtk) // check if attack
        {
            if (nowWeapon.style == 0)
            {
                Debug.Log("Attack");
                ani.Play("P_sword");
                Attack(); // invoke attack
            }
            else if (nowWeapon.style==1)
            {
                
                rangerAttack();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))//change weapon to sword
        {
            ChageWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))//hammer
        {
            ChageWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))//gun
        {
            ChageWeapon(3);
        }
    }
    public void rangerAttack()//gun attack
        {
        isAtk = false;
        GameObject bullet = GameObject.Instantiate(nowWeapon.bullets);
        bullet.GetComponent<BulletCollsion>().SetWeaponDamage(transform.GetComponent<character>().strength,nowWeapon.damage);
        bullet.transform.position = atkPos.transform.position;
        bullet.transform.localScale = transform.localScale;
        StartCoroutine(WaitShoot());
        }
   

    void Attack()//attack 
    {
        //play attack animation
        ani.SetBool("attack", true);
        //attack box visible when attack
        atkPos.SetActive(true);
        isAtk = false;
        //cd for attack
        StartCoroutine(WaitAtk());
        
    }
    IEnumerator WaitAtk()//time wait for next attack
    {
        yield return new WaitForSeconds(0.2f);
        atkPos.SetActive(false);
        ani.SetBool("attack", false);
        isAtk = true;
    }


    IEnumerator WaitShoot()//time wait for next shoot
    {
        yield return new WaitForSeconds(1f);
        atkPos.SetActive(false);
        isAtk = true;
    }
}
