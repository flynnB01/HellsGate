using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{

    private float startPos_x, startPos_y, length;
    public new GameObject camera;
    public float parallax; // speed bg moves with camera

    // Start is called before the first frame update
    void Start()
    {
        startPos_x = transform.position.x;
        startPos_y = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // 0 = moving with camera, 1 = not moving, 0.5 = in between
        float distance_x = camera.transform.position.x * parallax;
        float distance_y = camera.transform.position.y * parallax;
        float movement = camera.transform.position.x * (1 - parallax);

        transform.position = new Vector3(startPos_x + distance_x, startPos_y + distance_y, transform.position.z);

        if (movement > startPos_x + length) // if bg has moved to the end of its own length, change position to give illusion of infinite scrolling
        {
            startPos_x += length;
        }
        else if (movement < startPos_x - length)
        {
            startPos_x -= length;
        }
    }
}
