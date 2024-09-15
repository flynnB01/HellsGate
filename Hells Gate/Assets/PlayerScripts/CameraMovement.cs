using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // player obj that cam will follow

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + 3.5f, player.position.y + 2.0f, -10.0f);
    }
}
