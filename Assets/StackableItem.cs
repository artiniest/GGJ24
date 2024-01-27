using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableItem : MonoBehaviour
{
    private bool _shouldDestroyNextFrame = false;
    private Collider _other;

    private int _destroyCountdown = 10;

    public bool IsHandling = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == this. gameObject.layer)
        {
            if (other.GetComponent<StackableItem>().IsHandling)
                return;

            IsHandling = true;

            Debug.Log(other.name);

            other.transform.parent.SetParent(this.transform.parent);
            _other = other;
            
            _shouldDestroyNextFrame = true;
        }
    }

    private void Update()
    {
        if (_shouldDestroyNextFrame && IsHandling)
        {
            if (_destroyCountdown > 0)
            {
                _destroyCountdown -= 1;
                return;
            }

            Destroy(this.gameObject);
            Destroy(_other.gameObject);

            Destroy(_other.transform.parent.GetComponent<Rigidbody>());
        }
    }
}
