// Written by Josh Xiong
// 3/12/2022
// Singleton
// Purpose: ensures class has one instance globally -- Singleton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Music : MonoBehaviour
{
    private static Music instance;

    // Music by scene 
    public AudioClip musicStart;
    public AudioClip musicIsaac;
    public AudioClip musicJosh;
    public AudioClip musicNicole;
    public AudioClip musicMike;
    public AudioClip musicWin;
    public AudioClip musicLose;

    // To ensure the music doesn't repeat again
    private bool hasPlayed = false;

    // The source to play the audio clip
    private AudioSource audioSource;

    private string currentScene;

    // Singleton for the object
    public void Awake()
    {
        // Delete newly created music for each scene
        if (instance != null)
        {
            Destroy(gameObject);
        }
        // Don't destroy instance when moving to new scene
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().name;

    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicStart, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "IsaacScene")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicIsaac, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "JoshScene")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicJosh, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "MikeScene")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicMike, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "NicoleScene")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicNicole, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "YouWin")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicWin, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "YouLose")
        {
            if (hasPlayed == false)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(musicLose, 3);

                hasPlayed = true;
            }
        }

        // Assure the boolean is resetted
        if (SceneManager.GetActiveScene().name != currentScene)
        {
            hasPlayed = false;
            currentScene = SceneManager.GetActiveScene().name;
        }
    }
}
