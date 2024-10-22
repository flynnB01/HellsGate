using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollsion : MonoBehaviour
{
    public int direction;
    public float bulletSpeed = 50;
    public float strength;
    public character player;
    // Start is called before the first frame update
    void Start()
    {

        if (transform.localScale.x >= 0)//check direction of bullet shoot
        {
            direction = -1;
        }
        else if(transform.localScale.x <=0 ) 
        {
            direction = 1;
        }
        StartCoroutine(BulletGone());
    }
    IEnumerator BulletGone()//after 2s, the bullet gone
    { 
        yield return new WaitForSeconds(2);
        GameObject.Destroy(gameObject);
    }


    public void SetWeaponDamage(float strength,float weaponDamage)
    {
        strength = strength*weaponDamage; //dmg dealt by attack is strength * weapon
        Debug.Log(strength);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))//hits enemy dealt dmg 
        {
            collision.gameObject.GetComponent<enemy>().takeDmg((int)strength);
            Debug.Log(strength);
            GameObject.Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))//hits boss dealt dmg 
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.takeDmg((int)strength);
            Debug.Log(strength);
            GameObject.Destroy(gameObject);
        }


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * direction * bulletSpeed *Time.deltaTime); //bullet shoot
       
    }
}
