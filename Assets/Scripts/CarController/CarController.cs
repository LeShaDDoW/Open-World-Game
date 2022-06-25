using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("The MotorSphere of the Car!")] public Rigidbody sphereRb;
    [Tooltip("How fast he goin!")] public float fwdSpeed;
    [Tooltip("How fast he goin in reverse!")] public float revSpeed;
    [Tooltip("How fast he rotatin!")] public float turnSpeed;
    [Tooltip("The Player GameObject!")] public PlayerController player;

    float moveInput;
    float turnInput;
    float newRotation;

    bool grounded = true;

    private void Start()
    {
        sphereRb.transform.parent = null;
    }

    void Update()
    {
        if(player.inCar == true) GetInput();
        if(Physics.SphereCast(sphereRb.transform.position, .1f, Vector3.down, out RaycastHit hit)) grounded = true;
        else grounded = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = sphereRb.transform.position;
        sphereRb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);

        transform.Rotate(0, newRotation, 0, Space.World);
    }

    void GetInput()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;
        newRotation = moveInput >= 0 ? turnInput * turnSpeed * Time.deltaTime : -turnInput * turnSpeed * Time.deltaTime;
    }

    
}
