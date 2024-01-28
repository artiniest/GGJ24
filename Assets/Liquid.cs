using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public string layerToIgnore = "Glass";

    void Start()
    {
        // Ignore collisions between the current GameObject's layer and the specified layer
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer(layerToIgnore));
    }
}
