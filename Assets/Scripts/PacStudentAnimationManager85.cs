using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentAnimationManager85 : MonoBehaviour
{
    private Animator animator; // Corresponds to the Animator component controlling PacStudent's animations
    private SpriteRenderer spriteRenderer;

    // These variables are used to calculate PacStudent's movement direction
    // Since they all share the same walking animation, we simply need to rotate it for each direction and flip the sprite
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the components attached to the gameObject
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initializing the position variables
        currentPosition = transform.position;
        previousPosition = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the position variables
        previousPosition = currentPosition;
        currentPosition = transform.position;

        // Calculating PacStudent's movement direction based on position change
        movementDirection = currentPosition - previousPosition;

        // Check direction and rotate PacStudent accordingly
        if (movementDirection.x > 0) // If PacStudent is moving right
        {
            spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0); // PacStudent gets rotated to 0º
        }
        else if (movementDirection.y < 0) // If PacStudent is moving down
        {
            spriteRenderer.flipX = false; // PacStudent's sprite gets flipped
            transform.rotation = Quaternion.Euler(0, 0, 270); // PacStudent gets rotated to 270º
        }
        else if (movementDirection.x < 0) // If PacStudent is moving left
        {
            spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(0, 0, 0); // PacStudent gets rotated to 0º
        }
        else if (movementDirection.y > 0) // If PacStudent is moving up
        {
            spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 90); // PacStudent gets rotated to 90º
        }
    }
}
