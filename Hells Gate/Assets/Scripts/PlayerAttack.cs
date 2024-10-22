using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private BoxCollider2D box;
    public character player;
    private float strength;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Update(){
        strength = player.strength;
    }

    public void SetWeaponDamage(float weaponDamage)
    {

        strength *= weaponDamage; // ENABLE THIS ONCE ADDED A WEAPON_____________________________________________________________________
    }
    //when play attack, turn attackbox on
    /*public void AtkStar()
    {
        box.enabled = true;
    }

    //close attackbox when attack is over
    public void AtkOver()
    {
        box.enabled = false;
    }*/

    //public void hitsEnemey(Collider2D collision)//if attack box detect enemy, dealt dmg
    //{
    //    collision.GetComponent<enemy>().takeDmg(10);
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemy>().takeDmg((int)strength);

        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();  
            boss.takeDmg((int)strength);
        }
    }
}
