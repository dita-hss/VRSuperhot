using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI3 : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float teleportInterval = 5f;
    [SerializeField]
    private GameObject playerTarget;
    private float initialYPosition;
    private float lastTeleportTime;
    public GameObject plane;

    private Renderer planeRenderer;


    void Start() {
        planeRenderer = plane.GetComponent<Renderer>();
        initialYPosition = transform.position.y;
        lastTeleportTime = Time.time;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 7 || other.gameObject.CompareTag("Player")) {
            playerTarget = other.gameObject;
        }
    }

    void Update() {
        if (playerTarget != null) {
            // enemy looks at player and moves towards player all the time
            Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, transform.position.y, playerTarget.transform.position.z);
            transform.LookAt(targetPosition);
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        //when to random teleport
        if (Time.time > lastTeleportTime + teleportInterval) {
            TeleportToRandomPosition();
            lastTeleportTime = Time.time;
        }
    }

    void TeleportToRandomPosition() {
        Vector3 newPosition = GetRandomPositionOnPlane();
        transform.position = newPosition;
    }

    Vector3 GetRandomPositionOnPlane() {
        // bounds of the plane on xz plane
        Bounds planeBounds = planeRenderer.bounds;

        // random x and Z positions within the bounds of the plane
        float randomX = Random.Range(planeBounds.min.x, planeBounds.max.x);
        float randomZ = Random.Range(planeBounds.min.z, planeBounds.max.z);

        // so its not inside
        float yPosition = planeBounds.max.y;
        return new Vector3(randomX, yPosition, randomZ);
    }
}
