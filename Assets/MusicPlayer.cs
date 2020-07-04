using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        // dont destroy the component I'm attached to
        DontDestroyOnLoad(gameObject);    
    }

    void Start()
    {
        Invoke("LoadScene", 2.0f);
    }

    // Update is called once per frame
    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
