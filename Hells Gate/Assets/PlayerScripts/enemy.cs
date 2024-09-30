using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // init enemy stats
    public int expValue;
    public int hp=10;
    public HealthBar enemyHpBar;
    public difficulty difficultyScript;//manages difficulty

    void Death() // when enemy dies
    {
        if (expManager.Instance)
            expManager.Instance.AddExp(expValue);
        Destroy(gameObject);
        Debug.Log("die");
    }
   public void takeDmg(int damage)// enemy lose hp 
    {
        if(difficultyScript.isEasy){
            damage = (int)(damage * 1.3f);
        }
        
        if(difficultyScript.isHard){
            damage = (int)(damage * 0.6f);
        }

        Debug.Log("enemy damage taken");
        hp -= damage;
        
        if (hp <= 0) {
            Death();
        }
        enemyHpBar.SetHealth(hp);
    }

    









}
