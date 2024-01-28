using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainScript : MonoBehaviour
{
    private Rigidbody rb;

    Vector3 scale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (this.transform.position.y <= -1.1f)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, -1.1f, transform.position.z), Quaternion.identity);
            if (rb != null) rb.velocity = Vector3.zero;
        }

    }
}
