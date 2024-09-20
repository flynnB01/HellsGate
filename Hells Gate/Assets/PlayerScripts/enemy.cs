using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // init enemy stats
    public int expValue;
    public int hp=10;
    public HealthBar enemyHpBar;

    void Death() // when enemy dies
    {
        expManager.Instance.AddExp(expValue);
        Destroy(gameObject);
        Debug.Log("die");
    }
   public void takeDmg(int damage)// enemy lose hp 
    {
        Debug.Log("enemy damage taken");
        hp -= damage;
        enemyHpBar.SetHealth(hp);
        if (hp <= 0) {
            Death();
        }
    }

    









}
