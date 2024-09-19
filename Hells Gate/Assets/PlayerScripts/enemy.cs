using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // init enemy stats
    public int expValue;
    public float hp=10;

    void Death() // when enemy dies
    {
        expManager.Instance.AddExp(expValue);
        Destroy(gameObject);
        Debug.Log("die");
    }
   public void takeDmg(float damage)// enemy lose hp 
    {
        Debug.Log("enemy damage taken");
        hp -= damage;
        if (hp <= 0) {
            Death();
        }
    }

    









}
