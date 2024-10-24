using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowManager : MonoBehaviour
{
    enum position { up, down };

    private position arrowposition;
    private Transform arrowTransform;
    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        // Loading the UIManager in order to call its functions
        uiManager = GameObject.FindFirstObjectByType<UIManager>();
        // Loading the Arrow transform
        arrowTransform = GetComponent<Transform>();
        // Initialising the position
        arrowposition = position.up;
        arrowTransform.position = new Vector3(-4.5f, -2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && arrowposition == position.up) // If enter gets pressed
        {
            uiManager.LoadFirstLevel();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && arrowposition != position.up)
        {
            arrowposition = position.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && arrowposition != position.down)
        {
            arrowposition = position.down;
        }

        if (arrowposition == position.up)
        {
            // Changing the arrow position to Up
            arrowTransform.position = new Vector3(-4.5f, -2f, 0f);
        }
        else if (arrowposition == position.down)
        {
            // Changing the arrow position to down
            arrowTransform.position = new Vector3(-4.5f, -4f, 0f);
        }
    }
}
