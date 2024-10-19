using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healingAmount = 20; // Define how much health this pack heals
    public HealthPackSpawner spawner; // Reference to the spawner

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            character player = collision.gameObject.GetComponent<character>();
            if (player != null)
            {
                HealPlayer(player); // Heal the player
                spawner?.SpawnPack(); // Trigger spawning of a new health pack
                Destroy(gameObject); // Destroy the current health pack
            }
            else
            {
                Debug.Log("No character component found on player.");
            }
        }
    }

    public void HealPlayer(character player)
    {
        Debug.Log("Player Healed");
        player.ReceiveHealth(healingAmount);
    }
}