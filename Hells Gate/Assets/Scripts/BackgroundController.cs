using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{

    private float startPos, length;
    public GameObject camera;
    public float parallax; // speed bg moves with camera

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // 0 = moving with camera, 1 = not moving, 0.5 = in between
        float distance = camera.transform.position.x * parallax;
        float movement = camera.transform.position.x * (1 - parallax);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + length) // if bg has moved to the end of its own length, change position to give illusion of infinite scrolling
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
