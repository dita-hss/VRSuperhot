using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Game Over");
		string currentSceneName = SceneManager.GetActiveScene().name;
	    SceneManager.LoadScene(currentSceneName);
    }
}
