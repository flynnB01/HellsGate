using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// utility class which can be used by various enemies
public class EnemyDamage : MonoBehaviour 
{
    public int damage; // how much damage enemy can deal

    public character pc; // player character obj

    // TEMP - change bc enemy wont deal damage just by touching player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if enemy detects player collision 
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dmg taken");

        
            pc.TakeDamage(damage);
        }
    }
}
