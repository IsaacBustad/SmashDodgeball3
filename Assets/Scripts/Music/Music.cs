// Written by Josh Xiong
// 3/12/2022
// Singleton
// Purpose: ensures class has one instance globally

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Music : MonoBehaviour
{
    private static Music instance;

    public AudioClip musicStart;
    public AudioClip musicInGame;
    private bool hasPlayed = false;

    private AudioSource audioSource;

    private string currentScene;



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
                audioSource.PlayOneShot(musicInGame, 3);

                hasPlayed = true;
            }
        }

        if (SceneManager.GetActiveScene().name != currentScene)
        {
            hasPlayed = false;
            currentScene = SceneManager.GetActiveScene().name;
        }
    }
}
