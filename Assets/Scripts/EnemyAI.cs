using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameObject playerTarget;

    private float initialYPosition;

    void Start() {
        initialYPosition = transform.position.y;
    }

    // When the player enters the trigger, assign it as a target
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 7 || other.gameObject.CompareTag("Player")) {
                //Debug.Log("Enemy sees player");
            playerTarget = other.gameObject;
        }

        //playerTarget = other.gameObject;
    }

    // Update is called once per frame
    void Update() {
        // Only move forward if there is a player target
            //n dont move in the y direction "walking effect' sorta ( no animations :( )
        if (playerTarget != null) {

            Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, transform.position.y, playerTarget.transform.position.z);
            transform.LookAt(targetPosition);
            transform.position += transform.forward * Time.deltaTime * speed;


            // transform.LookAt(playerTarget.transform.position);
            // transform.position += transform.forward * Time.deltaTime * speed;
        } 
    }

    
}
