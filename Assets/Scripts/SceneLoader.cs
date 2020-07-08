using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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