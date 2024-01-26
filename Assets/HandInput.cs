using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInput : MonoBehaviour
{
    public float Speed = 5f;

    public float RotationSpeed = 100f;

    public GameObject HandObject;

    private void Update()
    {
        // Get WASD input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get E R input
        float updownInput = Input.GetAxis("UpDown");

        //Get X C input
        float rotationInput = Input.GetAxis("Rotation");
        // float rotation2Input = Input.GetAxis("Rotation2");

        // Calculate movement direction
        // Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 movement = new Vector3(horizontalInput, updownInput, verticalInput);
        movement = Camera.main.transform.TransformDirection(movement);

        // Move the GameObject in 3D space
        transform.Translate(movement * Speed * Time.deltaTime);

        if (HandObject)
        {
            HandObject.transform.Rotate(Vector3.forward * rotationInput * RotationSpeed * Time.deltaTime);
            // HandObject.transform.Rotate(Vector3.up * rotation2Input * RotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.gameObject.name);
    }
}
