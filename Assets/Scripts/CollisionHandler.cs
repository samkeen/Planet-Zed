using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("in seconds")][SerializeField] private float levelLoadDelay = 2f;
    [Tooltip("FX prefab on player")][SerializeField] private GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("OnPlayerDeath");
        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
