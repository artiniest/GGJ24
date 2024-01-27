using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableItem : MonoBehaviour
{
    private bool _shouldDestroyNextFrame = false;
    private StackableItem _other;

    private int _destroyCountdown = 10;

    public bool IsHandling = false;

    public GrabbableObject GrabbableParent => _grabbableParent;
    private GrabbableObject _grabbableParent;

    private void Awake()
    {
        _grabbableParent = transform.parent.GetComponentInParent<GrabbableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == this. gameObject.layer)
        {
            _other = other.GetComponent<StackableItem>();
            if (_grabbableParent == null && _other.GrabbableParent != null)
                return;
            
            if (other.GetComponent<StackableItem>().IsHandling)
                return;

            IsHandling = true;

            //Debug.Log(other.name);

            other.transform.parent.SetParent(_grabbableParent.transform);
            
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
            Destroy(_other.GrabbableParent.gameObject);

            Main.Instance.AddToScore();
        }
    }
}
