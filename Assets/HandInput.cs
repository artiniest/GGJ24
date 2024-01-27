using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInput : MonoBehaviour
{
    public float Speed = 5f;

    public float RotationSpeed = 100f;

    private float lHorizontalInput = 0f;
    private float lVerticalInput = 0f;
    private float lUpdownInput = 0f;
    private float lRotationInput = 0f;

    private float rHorizontalInput = 0f;
    private float rVerticalInput = 0f;
    private float rUpdownInput = 0f;
    private float rRotationInput = 0f;

    public KeyCode actionKey = KeyCode.Space;
    private bool isHolding = false;
    private GameObject heldObject;

    public GameObject HandObject;

    private void Update()
    {
        // Get WASD input


        if (Input.GetAxis("LTrigger") > 0){
            lUpdownInput = Input.GetAxis("LVertical");
            lRotationInput = Input.GetAxis("LHorizontal");
            rUpdownInput = Input.GetAxis("RVertical");
            rRotationInput = Input.GetAxis("RHorizontal");
        } else {
            lHorizontalInput = Input.GetAxis("LHorizontal");
            lVerticalInput = Input.GetAxis("LVertical");
            rHorizontalInput = Input.GetAxis("RHorizontal");
            rVerticalInput = Input.GetAxis("RVertical");
        }

        // Get E R input

        //Get X C input
        // float rotation2Input = Input.GetAxis("Rotation2");

        // Calculate movement direction
        Vector3 lMovement = new Vector3(lHorizontalInput, lUpdownInput, lVerticalInput);
        lMovement = Camera.main.transform.TransformDirection(lMovement);

        Vector3 rMovement = new Vector3(rHorizontalInput, rUpdownInput, rVerticalInput);
        rMovement = Camera.main.transform.TransformDirection(rMovement);


        // Move the GameObject in 3D space
        transform.Translate(lMovement * Speed * Time.deltaTime);
        transform.Translate(rMovement * Speed * Time.deltaTime);

        if (HandObject)
        {
            HandObject.transform.Rotate(Vector3.forward * lRotationInput * RotationSpeed * Time.deltaTime);
            HandObject.transform.Rotate(Vector3.forward * rRotationInput * RotationSpeed * Time.deltaTime);
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
