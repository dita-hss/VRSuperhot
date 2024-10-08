using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    private float shootRange = 20f;
    private float shootInterval = 1.5f;
    private float lastShootTime;

    public GameObject bulletTemplate;
    public float shootPower = 1000f;

    private GameObject playerTarget;


    private void OnTriggerEnter(Collider other) {
        //shoot at player tags or things on player layer
        if (other.gameObject.layer == 7 || other.gameObject.CompareTag("Player")) {
                //Debug.Log("Enemy sees player");
            playerTarget = other.gameObject;
        }
    }
    void Update() {
        //look at player and shoot at player
            // fixed bug: if player is destroyed, enemy will still try to shoot at player
        if (playerTarget != null && this != null && this.gameObject != null && gameObject.activeSelf) {
            transform.LookAt(playerTarget.transform.position);
            float distance = Vector3.Distance(transform.position, playerTarget.transform.position);
            //only shoot if player is within range and enough time has passed since last shot
            if (distance <= shootRange && Time.time > lastShootTime + shootInterval) {
                ShootAtPlayer();
                lastShootTime = Time.time;
            }
        } else {
            playerTarget = null;
        }
        
    }

    void ShootAtPlayer() {
        //shoot bullet at player
        GameObject bullet = Instantiate(bulletTemplate, transform.position + transform.forward * 2, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Vector3 shootDirection = (playerTarget.transform.position - transform.position).normalized;
        rb.AddForce(shootDirection * shootPower);
        Destroy(bullet, 2f);
        playerTarget = null;
    }
}

