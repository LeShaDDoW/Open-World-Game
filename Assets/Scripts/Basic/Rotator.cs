using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool sky;

    public float speed;

    void Update()
    {
        if (sky)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
    }
}
