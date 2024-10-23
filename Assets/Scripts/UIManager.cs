using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync("FirstScene", LoadSceneMode.Single); // Single instead of Additive because the goal is to replace the current Start Scene
    }

    private void Awake()
    {   // Added to avoid the Managers GameObject being deleted when changing scenes
        DontDestroyOnLoad(gameObject);
    }
}
