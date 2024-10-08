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

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.CompareTag("CubeEnemy")) {
            spawnManager.DestroyCubeEnemy(other.gameObject);

            //because the among us has multiple colliders
        } else if (other.transform.root.CompareTag("AmongUsEnemy")) {
            spawnManager.DestroyAmongUsEnemy(other.transform.root.gameObject);
        } else if (other.transform.root.CompareTag("BlackAmongUsEnemy")) {
            spawnManager.DestroyBlackAmongUsEnemy(other.transform.root.gameObject);
        } else if (other.transform.root.CompareTag("GAmongUsEnemy")) {
            spawnManager.DestroyGreenAmongUsEnemy(other.transform.root.gameObject);
        }
    }
}
