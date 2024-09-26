using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip PacStudentWalkingMusic;   // Music for when PacStudent is moving
    // These variables are used to calculate if PacStudent's moving
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    // Variable to ensure the sound doesn't start all over again on each frame update
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        // Safety check
        if (audioSource == null || PacStudentWalkingMusic == null)
        {
            Debug.LogWarning("AudioSource or AudioClip have not been assigned properly");
            return;
        }

        // Initializing the position variables
        currentPosition = transform.position;
        previousPosition = currentPosition;

        audioSource.clip = PacStudentWalkingMusic;
        audioSource.loop = true;
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the current position variable
        currentPosition = transform.position;
        if (currentPosition != previousPosition)
        {
            if (!isWalking)
            {
                // Playing the Walking Music
                audioSource.Play();
                isWalking = true;

            }
        }
        else if (isWalking)
        {
            // Stopping the Walking Music
            audioSource.Stop();
            isWalking = false;
        }

        // Updating the previous position variable
        previousPosition = currentPosition;
    }
}
