using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject CubeTemplate;

    public int maxEnemies = 10;

    // keeping track of the enemies that are spawned and where they can be spawned
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject plane;
    private Renderer planeRenderer;

    void Start() {
        planeRenderer = plane.GetComponent<Renderer>();
        for (int i = 0; i < maxEnemies; i++) {
            SpawnEnemy();
        }
    }

    void Update() {
        // make sure there is always x amount of enemies
        if (enemies.Count < maxEnemies) {
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        // some random position on the surface of the plane , spawn an enemy , add to tracker
        Vector3 randomPosition = GetRandomPositionOnPlane();

        GameObject newEnemy = Instantiate(CubeTemplate, randomPosition, transform.rotation);
        enemies.Add(newEnemy);
    }


    // destroy enemy and update list
    public void DestroyEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy);
    }

    Vector3 GetRandomPositionOnPlane() {
        // bounds of the plane on xz plane
        Bounds planeBounds = planeRenderer.bounds;

        // random x and Z positions within the bounds of the plane
        float randomX = Random.Range(planeBounds.min.x, planeBounds.max.x);
        float randomZ = Random.Range(planeBounds.min.z, planeBounds.max.z);

        // so its not inside
        float yPosition = planeBounds.max.y + 0.5f;

        return new Vector3(randomX, yPosition, randomZ);
    }
}

