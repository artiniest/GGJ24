using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    // public float shakeThreshold = 5f; // Adjust the threshold as needed
    // public float checkInterval = 0.1f; // Interval to check for shaking
    // private Vector3 lastMousePosition;

    // public bool IsShakingMouse => _isShakingMouse;

    // private bool _isShakingMouse = false;

    // void Awake()
    // {
    //     Cursor.visible = true;

    //     lastMousePosition = Input.mousePosition;
    // }

    // private float shakenFrames = 0f;

    // void Update()
    // {
    //     Vector3 currentMousePosition = Input.mousePosition;
    //     float mouseMovement = Vector3.Distance(currentMousePosition, lastMousePosition);

    //     if (mouseMovement > shakeThreshold * 10)
    //     {
    //         if (_isShakingMouse)
    //         {
    //             shakenFrames += 0.001f;
    //         }

    //         // Mouse is being shaken vigorously
    //         Debug.Log("Mouse Shake Detected!");
    //         _isShakingMouse = true;
    //     }
    //     else
    //     {
    //         shakenFrames = 0;
    //         _isShakingMouse = false;
    //     }

    //     lastMousePosition = currentMousePosition;
    // }
}
