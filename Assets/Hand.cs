using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject RotationObject;
    public Transform HoldPivot;

    private GameObject _heldObject;
    public GameObject HeldObject => _heldObject;

    private List<GameObject> _collidingObjects = new List<GameObject>();

    private bool _isHolding;
    public bool IsHolding => _isHolding;

    public void NotifyOnTrigger(Collider other)
    {
        Debug.Log(this.gameObject.name + " collided with " + other.name);
        // _heldObject = other.gameObject;
        _collidingObjects.Add(other.gameObject);
    }

    public void NotifyOnTriggerExit(Collider other)
    {
        if (_collidingObjects.Contains(other.gameObject))
            _collidingObjects.Remove(other.gameObject);
        // Check if the collider belongs to the held object
        // if (other.gameObject == HeldObject)
        // {
        //     _heldObject = null;
        // }
    }

    public void TryPickUpObject()
    {
        if (_collidingObjects.Count <= 0) //Not colliding with anything
            return;

        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        foreach(var obj in _collidingObjects)
        {
            if (closest == null)
            {
                closest = null;
            }

            float distance = Vector3.Distance(this.transform.position, obj.transform.position);

            if (distance < closestDistance)
            {
                closest = obj;
                closestDistance = distance;
            }
        }

        _heldObject = closest;

        _isHolding = true;
        _heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics on the object
        _heldObject.transform.parent = HoldPivot; // Attach the object to the hand
        var _heldComp = _heldObject.GetComponent<StackableItem>();
        if (_heldComp != null) _heldComp.IsHeld = true;

        // _isHolding = true;
        // _heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics on the object
        // _heldObject.transform.parent = RotationObject.transform; // Attach the object to the hand
        // var _heldComp = _heldObject.GetComponent<StackableItem>();
        // if (_heldComp != null) _heldComp.IsHeld = true;
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
