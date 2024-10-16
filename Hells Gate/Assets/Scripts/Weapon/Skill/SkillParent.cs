using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//skills lists
public class SkillParent : MonoBehaviour
{
    public  float mana;//mana cost 
    public float damage;//how muh demage the skills will dealt
    public float cd;//cooldown

    public  virtual void Skill( )
    {
        //how the skills performance
    }

    public virtual void SkillOver()
    {
        //skills end
    }

    public void OnTriggerEnter2D(Collider2D collision)//skills trigger 
    {
        skillCollision(collision);
    }

    public virtual void skillCollision(Collider2D collision)
    { 
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
