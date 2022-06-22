using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool sky;
    public bool rotateSky;
    public Transform player;

    public float speed;

    void Update()
    {
        if (sky)
        {
            if(rotateSky) transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            transform.position = player.position;
        }
    }
}
