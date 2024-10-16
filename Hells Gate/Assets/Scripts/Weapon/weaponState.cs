using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponState : MonoBehaviour
{
    public float attack = 10;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//dealt dmg to enemy
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
           
        //    transform.parent.GetComponent<PlayerAttack>().hitsEnemey(collision);
        //}
    }
   
}
