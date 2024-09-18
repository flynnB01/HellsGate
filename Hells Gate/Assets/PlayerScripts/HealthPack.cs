using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public character player;
    public int healing;

    
    public void healPlayer()
    {
            Debug.Log("Player Healed");
            player.ReceiveHealth(healing);
            Destroy(gameObject);
    }
}
