using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovementManager : MonoBehaviour
{
    private Vector3[] corners;
    private int currentCorner = 0;
    [SerializeField] private float speed = 4.0f; // Chosen speed for PacStudent

    // Start is called before the first frame update
    void Start()
    {
        corners = new Vector3[4];
        corners[0] = new Vector3(-7.5f, 13.5f, 0);    // Top right corner
        corners[1] = new Vector3(-7.5f, 9.5f, 0);     // Bottom right corner
        corners[2] = new Vector3(-12.5f, 9.5f, 0);    // Bottom left corner
        corners[3] = new Vector3(-12.5f, 13.5f, 0);   // Tope left corner

        StartCoroutine(MovePacStudent85());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePacStudent85()
    {
        while (true) // Setting up an infinite loop
        {
            // Updating target's position to the next corner
            Vector3 target = corners[currentCorner];

            // Moving PacStudent towards the next corner
            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                // Using deltaTime to ensure frame-rate independent motion
                // Using MoveTowards to ensure programmatic tweening
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                // Waiting until the next frame
                yield return null;
            }

            // Actually changing PacStudent's position to the corner position
            transform.position = target;


            // Calculating the next corner
            currentCorner = (currentCorner + 1) % 4;
        }
    }
}
