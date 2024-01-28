using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Hand LHand;

    [SerializeField]
    private Hand RHand;

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

    // public KeyCode LActionKey = KeyCode.Space;
    // public KeyCode RActionKey = KeyCode.Space;

    private void Update()
    {
        testKeysAndAxis();

        if (Input.GetButtonDown("Restart"))
        {
            LoadScene.Instance.LoadSceneByName("Game");
        }
        
        // Get input for left hand
        if (Input.GetAxis("LTrigger") > 0)
        {
            lHorizontalInput = 0f;
            lVerticalInput = 0f;

            lUpdownInput = Input.GetAxis("LVertical");
            lRotationInput = Input.GetAxis("LHorizontal") * -1;
        }
        else
        {
            lUpdownInput = 0f;
            lRotationInput = 0f;

            lHorizontalInput = Input.GetAxis("LHorizontal");
            lVerticalInput = Input.GetAxis("LVertical");
        }

        if (Input.GetAxis("RTrigger") > 0)
        {
            rHorizontalInput = 0f;
            rVerticalInput = 0f;

            rUpdownInput = Input.GetAxis("RVertical");
            rRotationInput = Input.GetAxis("RHorizontal") * -1;
        }
        else
        {
            rUpdownInput = 0f;
            rRotationInput = 0f;

            rHorizontalInput = Input.GetAxis("RHorizontal");
            rVerticalInput = Input.GetAxis("RVertical");
        }

        // Calculate movement direction
        Vector3 lMovement = new Vector3(lHorizontalInput, lUpdownInput, lVerticalInput);
        lMovement = Camera.main.transform.TransformDirection(lMovement);

        Vector3 rMovement = new Vector3(rHorizontalInput, rUpdownInput, rVerticalInput);
        rMovement = Camera.main.transform.TransformDirection(rMovement);

        // Move the GameObject in 3D space
        LHand.transform.Translate(lMovement * Speed * Time.deltaTime);
        RHand.transform.Translate(rMovement * Speed * Time.deltaTime);

        if (LHand.RotationObject)
        {
            LHand.RotationObject.transform.Rotate(Vector3.forward * lRotationInput * RotationSpeed * Time.deltaTime);
            LHand.HoldPivot.transform.Rotate(Vector3.forward * lRotationInput * RotationSpeed * Time.deltaTime);
        }

        if (RHand.RotationObject)
        {
            RHand.RotationObject.transform.Rotate(Vector3.forward * rRotationInput * RotationSpeed * Time.deltaTime);
            RHand.HoldPivot.transform.Rotate(Vector3.forward * rRotationInput * RotationSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("LAction") > 0)
        {
            if (!LHand.IsHolding)
            // Try to pick up an object
            LHand.TryPickUpObject();
        }
        else
        {
            // Release the held object
            LHand.ReleaseHeldObject();
        }

        if (Input.GetAxis("RAction") > 0)
        {
            if (!RHand.IsHolding)
            // Try to pick up an object
            RHand.TryPickUpObject();    
        }
        else
        {
            // Release the held object
            RHand.ReleaseHeldObject();
        }
    }

    void testKeysAndAxis()
    {
        // for (int i = 3; i <= 20; i++)
        // {
        //     float axisValue = Input.GetAxisRaw("Axis " + i.ToString());
        //     if (Mathf.Abs(axisValue) > 0.2) // Use some threshold to filter out idle noise
        //     {
        //         Debug.Log("Axis " + i + " value: " + axisValue);
        //     }
        // }
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Button pressed: " + i);
            }
        }
    }
}
