using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInput : MonoBehaviour
{
    public float Speed = 5f;

    public float RotationSpeed = 100f;


    public KeyCode actionKey = KeyCode.Space;
    private bool isHolding = false;
    private GameObject heldObject;

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
        Vector3 movement = new Vector3(horizontalInput, updownInput, verticalInput);
        movement = Camera.main.transform.TransformDirection(movement);

        // Move the GameObject in 3D space
        transform.Translate(movement * Speed * Time.deltaTime);

        if (HandObject)
        {
            HandObject.transform.Rotate(Vector3.forward * rotationInput * RotationSpeed * Time.deltaTime);

        }

        if (Input.GetKeyDown(actionKey))
        {
            if (!isHolding)
            {
                // Try to pick up an object
                TryPickUpObject();
            }
            else
            {
                // Release the held object
                ReleaseHeldObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            heldObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the held object
        if (other.gameObject == heldObject)
        {
            heldObject = null;
        }
    }

    void TryPickUpObject()
    {
        if (heldObject == null)
            return;

        isHolding = true;
        heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics on the object
        heldObject.transform.parent = HandObject.transform; // Attach the object to the hand
    }

    void ReleaseHeldObject()
    {
        if (heldObject == null)
            return;

        // Release the held object
        isHolding = false;

        heldObject.transform.parent = null; // Detach the object from the hand
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics on the object
        heldObject = null;
    }
}
