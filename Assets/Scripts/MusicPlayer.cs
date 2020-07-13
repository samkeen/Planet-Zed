using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;
        print("found music player count: " + musicPlayerCount);
        if (musicPlayerCount >1)
        {
            // destroy the component I'm attached to
            Destroy(gameObject);
        }
        else
        {
            // dont destroy the component I'm attached to
            DontDestroyOnLoad(gameObject);
        }
    }
}