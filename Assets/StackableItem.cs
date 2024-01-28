using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackableItem : MonoBehaviour
{
    private bool _shouldDestroyNextFrame = false;
    private StackableItem _otherStackable;
    private Collider _other;

    private int _destroyCountdown = 10;

    public bool IsHandling = false;

    public GrabbableObject GrabbableParent => _grabbableParent;
    private GrabbableObject _grabbableParent;

    // private void OnCollisionEnter(Collision other)
    // {
    //     // Debug.Log(other.gameObject.name);
    //     // if (other.gameObject.layer == this.gameObject.layer)
    //     // {
    //     //     var otherRigidbody = other.gameObject.GetComponent<Rigidbody>();

    //     //     if (otherRigidbody != null)
    //     //     {
    //     //         FixedJoint joint = gameObject.AddComponent<FixedJoint>();
    //     //         joint.connectedBody = otherRigidbody;
    //     //     }
    //     // }
    // }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer != this.gameObject.layer) return;

        if (collidingObjects.ContainsKey(other.collider))
        {
            collidingObjects.Remove(other.collider);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer != this.gameObject.layer || other.gameObject.GetComponent<Joint>() != null) return;
        
        if (!other.gameObject.GetComponent<StackableItem>().GrabbableParent.IsHeld && !_grabbableParent.IsHeld)

        if (!collidingObjects.ContainsKey(other.collider))
        {
            collidingObjects.Add(other.collider, 0.0f);
        }
    }

    private float collisionDuration = 1.0f;
    public Dictionary<Collider, float> collidingObjects = new Dictionary<Collider, float>();

    private void Update()
    {
        foreach(var entry in collidingObjects.ToList())
        {
            collidingObjects[entry.Key] += Time.deltaTime;
            
            if(entry.Value >= collisionDuration)
            {
                var otherRigidbody = entry.Key.gameObject.GetComponent<Rigidbody>();

                if (otherRigidbody)
                {
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = otherRigidbody;

                    collidingObjects.Remove(entry.Key);
                }
            }
        }
    }
}
