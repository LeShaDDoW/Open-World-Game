using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [Header("Stuffz")]
    [Tooltip("If you want the Sky to rotate forwards!")] public bool rotateSky;
    [Tooltip("The Player BEAN!")] public Transform player;
    [Tooltip("The Speed of the Sky Rotating!")] public float speed;

    void Update()
    {
        if(rotateSky) transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        transform.position = player.position;
    }
}
