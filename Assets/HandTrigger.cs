using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    private Hand _parent;

    private void Awake()
    {
        _parent = GetComponentInParent<Hand>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            _parent.NotifyOnTrigger(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _parent.NotifyOnTriggerExit(other);
    }
}
