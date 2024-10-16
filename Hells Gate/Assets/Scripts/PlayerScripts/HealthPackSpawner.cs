using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public bool active = true;
    public float packCooldown = 5f;
    public GameObject objectToSpawn;

    public void SpawnPack()
    {
        if (active)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            active = false; // Set spawner to inactive after spawning
            StartCoroutine(PackTimer());
        }
    }

    private IEnumerator PackTimer()
    {
        yield return new WaitForSeconds(packCooldown);
        active = true; // Set the spawner back to active
    }
}