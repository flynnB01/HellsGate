using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private float startPos;
    public GameObject camera;
    public float parallax; // speed bg moves with camera

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    void Update()
    {
        // 0 = moving with camera, 1 = not moving, 0.5 = in between
        float distance = camera.transform.position.x * parallax;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
