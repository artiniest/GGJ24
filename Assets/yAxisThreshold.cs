using UnityEngine;

public class YAxisThresholdRestrictor : MonoBehaviour
{
    public float thresholdY = 0.5f; // Set your desired threshold

    void Update()
    {
        // Check if the object's y-position is below the threshold
        if (transform.position.y < thresholdY)
        {
            // Set the y-position to the threshold, keeping x and z the same
            transform.position = new Vector3(transform.position.x, thresholdY, transform.position.z);
        }
    }
}
