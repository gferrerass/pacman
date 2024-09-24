using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationManager : MonoBehaviour
{
    private Animator animator; // Corresponds to the Animator component controlling the Ghost's animations
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool alive; // Indicates wether Ghost is currently alive (true) or not (false)
    // Start is called before the first frame update
    void Start()
    {
        // Getting the components attached to the gameObject
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initializing the alive state to "true"
        //alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) // If the ghost is alive
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walking_right"))
            {
                spriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walking_up"))
            {
                spriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walking_left"))
            {
                spriteRenderer.flipX = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walking_down"))
            {
                spriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                // For now, the ghost only changes directions in normal state. In the final version of the game this will b
                spriteRenderer.flipX = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
