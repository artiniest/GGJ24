using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioClip collisionSound; // Assign this in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play the sound if the HandObject collides with something
        audioSource.PlayOneShot(collisionSound);
    }

    // You can add more methods for other events
    // For example:
    // void SomeOtherEvent()
    // {
    //     audioSource.PlayOneShot(anotherSound);
    // }
}
