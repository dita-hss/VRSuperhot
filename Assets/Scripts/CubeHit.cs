using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHit : MonoBehaviour
{
    private SpawnEnemies spawnManager;
    void Start() {
        // spawn enemies instance
        spawnManager = GameObject.FindObjectOfType<SpawnEnemies>();
    }

    private void OnCollisionEnter(Collision other)
    {
        // destroy enemies when they collide with something and remove this enemy from spawnManager list
        if (other.gameObject.CompareTag("Enemy")) {
            spawnManager.DestroyEnemy(other.gameObject);
        }
    }
}
