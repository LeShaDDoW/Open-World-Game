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

    private void Start()
    {
        sphereRb.transform.parent = null;
    }

    void Update()
    {
        if (player.inCar == true) GetInput();
        sphereRb.AddForce(Vector3.down * Time.deltaTime * 3000, ForceMode.Acceleration);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = sphereRb.transform.position;
        sphereRb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);

        //GetComponent<Rigidbody>().AddTorque(new Vector3(0, newRotation, 0));
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    void GetInput()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxis/*Raw*/("Horizontal");
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;
        newRotation = turnInput * turnSpeed * Time.deltaTime * moveInput;
    }

    
}
