using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject RotationObject;

    private GameObject _heldObject;
    public GameObject HeldObject => _heldObject;

    private bool _isHolding;
    public bool IsHolding => _isHolding;

    // Move to Hand.cs
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Grabbable"))
    //     {
    //         _heldObject = other.gameObject;
    //     }
    // }

    public void NotifyOnTrigger(Collider other)
    {
        _heldObject = other.gameObject;
    }

    public void NotifyOnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the held object
        if (other.gameObject == HeldObject)
        {
            _heldObject = null;
        }
    }

    public void TryPickUpObject()
    {
        Debug.Log("Grabbing");
        if (_heldObject == null)
            return;

        _isHolding = true;
        _heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics on the object
        _heldObject.transform.parent = RotationObject.transform; // Attach the object to the hand
    }

    public void ReleaseHeldObject()
    {
        if (_heldObject == null)
            return;

        // Release the held object
        _isHolding = false;

        _heldObject.transform.parent = null; // Detach the object from the hand
        _heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics on the objectssss
        _heldObject = null;
    }
}
