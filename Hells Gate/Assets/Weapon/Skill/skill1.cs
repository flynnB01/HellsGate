using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1 : SkillParent
{
    Collider2D lastCollision;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public override void skillCollision(Collider2D collision) //if enemy in skillbox, lose hp
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<enemy>()
            .takeDmg((int)damage);
            Debug.Log("111111111111");
        }
        
    }

    public override void Skill( )
    {
       //how the skills performance

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SkillOver()
    {
       GameObject.Destroy(gameObject);
    }
}
