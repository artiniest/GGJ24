using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    public AudioClip heartBeat; // Assign this in the Inspector
    private AudioSource audioSource;

    private float targetTime = 4f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = heartBeat;
    }

    private void Update(){
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            targetTime = 4f;
            heartBeatEvent();
        }
    }

    void heartBeatEvent(){
        audioSource.PlayOneShot(heartBeat);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     // Play the sound if the HandObject collides with something
    //     audioSource.PlayOneShot(collisionSound);
    // }

    // You can add more methods for other events
    // For example:
    // void SomeOtherEvent()
    // {
    //     audioSource.PlayOneShot(anotherSound);
    // }
}
