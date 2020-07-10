using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;
    [SerializeField] private int scorePerHit = 30;
    [SerializeField] private int hitPoints = 3;
    private ScoreBoard scoreBoard;
    
    private void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            print("dying");
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints--;
        print("Hits at: " + hitPoints);
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy()
    {
        // render the explosion
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
