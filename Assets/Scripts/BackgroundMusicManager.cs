using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip GameIntroMusic;   // Background music for the game intro (when the level first starts)
    public AudioClip NormalStateMusic; // Background music for when ghosts are in their normal state
    private bool normalMusicplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        // Safety check
        if (audioSource == null || GameIntroMusic == null || NormalStateMusic == null)
        {
            Debug.LogWarning("AudioSource or AudioClip have not been assigned properly");
            return;
        }
        // Playing the game intro music when the level first starts
        PlayGameIntroMusic();
    }

    // Update is called once per frame
    void Update()
    {
        MusicUpdate();
    }

    void PlayGameIntroMusic()
    {
        // Playing the background music for the game intro (when the level first starts)
        audioSource.clip = GameIntroMusic;
        // Setting the game intro music to play on a loop
        audioSource.loop = true;
        audioSource.Play();
    }

    void PlayNormalStateMusic()
    {
        // PLaying the background music for when ghosts are in their normal state
        audioSource.clip = NormalStateMusic;
        // Setting the normal state music to play on a loop
        audioSource.loop = true;
        audioSource.Play();
    }

    bool FirstLevelLoaded => SceneManager.GetSceneByName("FirstScene").isLoaded;
    void MusicUpdate()
    {
        if (!normalMusicplaying && FirstLevelLoaded)
        {
            PlayNormalStateMusic();
            normalMusicplaying = true;
        }
    }
}
