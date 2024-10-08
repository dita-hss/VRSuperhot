using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
            //Debug.Log("Game Over");
        // if it collides w the enemy, restart the game
        if (other.gameObject.CompareTag("AmongUsEnemy") || other.gameObject.CompareTag("BlackAmongUsEnemy") || other.gameObject.CompareTag("CubeEnemy")) {
            SceneManager.LoadScene("Scenes/GameOverScene");
        }
		
    }
}
