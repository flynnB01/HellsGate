using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active = true;
    public HealthPack healthPack;
    public float packCooldown = 5f;
    public float packCurrentTime;
    public GameObject objectToSpawn;

    public character player;
    public int healing;
    void Start()
    {
        active = true;
        packCurrentTime = packCooldown;
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if enemy detects player collision 
        if (collision.gameObject.CompareTag("Player") && active == true)
        {
            Debug.Log("Contact with Health Pack");
            healthPack.healPlayer();
            active = false;
            StartCoroutine(PackTimer());
        }
    }

    private IEnumerator PackTimer()
    {
        // Wait for the cooldown duration
        yield return new WaitForSeconds(packCooldown);

        // After the wait, spawn a new health pack
        SpawnPack();
        active = true; // Set the spawner back to active

    }
    private void SpawnPack()
    {
        if(active == true)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
        
    }

    public void healPlayer()
    {
        Debug.Log("Player Healed");
        player.ReceiveHealth(healing);
        Destroy(gameObject);
    }
}
