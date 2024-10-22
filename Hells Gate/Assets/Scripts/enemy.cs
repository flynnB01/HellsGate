using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    // init enemy stats
    public int expValue;
    public int hp=10;
    //public HealthBar enemyHpBar;
    public difficulty difficultyScript;//manages difficulty

    void Death() // when enemy dies
    {
        if (expManager.Instance)
            expManager.Instance.AddExp(expValue); // give exp to player for defeating enemy
        Destroy(gameObject);
        Debug.Log("die");
    }
   public void takeDmg(int damage)// enemy lose hp 
    {
<<<<<<< HEAD
        Debug.Log(damage);
        if(difficultyScript.isEasy){
=======
        float sceneID = SceneManager.GetActiveScene().buildIndex; // get current scene id;

        // change amount of damage taken depending on difficulty
        if (difficultyScript.isEasy){
>>>>>>> 197a83e482ca999c7c465bdd6705d6cdaee3d575
            damage = (int)(damage * 1.3f);
        }
        
        if(difficultyScript.isHard){
            damage = (int)(damage * 0.6f);
        }

        switch (sceneID) // decreases damage taken by enemy depending on scene
        {
            case 2: damage = (int)(damage * 0.8f); break;
            case 3: damage = (int)(damage * 0.6f); break;
        }

        Debug.Log("enemy damage taken: " + damage);
        hp -= damage; // decrement hp using damage value
        
        // if hp less than 0, call death function
        if (hp <= 0) {
            Death();
        }
        //enemyHpBar.SetHealth(hp);
    }

    









}
