using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudent_Start_Animation_Manager : MonoBehaviour
{
    public Animator ghost0Animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // For safety reasons, checking if Ghost_0 exists
        GameObject ghost0 = GameObject.Find("Ghost_0");

        if (ghost0 != null) // For safety reasons, checking if Ghost_0 exists
        {
            // Getting the animator from Ghost_0
            ghost0Animator = ghost0.GetComponent<Animator>();

            if (ghost0Animator == null) // For safety reasons, checking if Ghost_0's animator exists
            {
                Debug.LogError("Ghost_0's animator doesn't exist or not found");
            }
        }
        else
        {
            Debug.LogError("Ghost0's GameObject doesn't exist or not found");
        }

        // Getting the SpriteRenderer component attached to PacStudent
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null) // For safety reasons, checking if the SpriteRenderer component is found on PacStudent
        {
            Debug.LogError("SpriteRenderer component not found on PacStudent.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ghost0Animator != null) // For safety reasons, checking if Ghost_0's animator exists
        {
            AnimatorStateInfo ghostStateInfo = ghost0Animator.GetCurrentAnimatorStateInfo(0);

            // Checking if Ghost0 is in the "Walking_left" state
            if (ghostStateInfo.IsName("Walking_left"))
            {
                spriteRenderer.flipX = true; // Flipping the sprite
            }
            else
            {
                spriteRenderer.flipX = false; // Setting the sprite to its original flip value
            }
        }
    }
}

