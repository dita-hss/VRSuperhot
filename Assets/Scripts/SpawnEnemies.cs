using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public GameObject CubeTemplate;
    public GameObject AmongUsTemplate;
    public GameObject blackAmongUsTemplate;

    public int maxEnemies = 21;

    // keeping track of the enemies that are spawned and where they can be spawned
    private List<GameObject> cubeEnemies = new List<GameObject>();
    private List<GameObject> amongUsEnemies = new List<GameObject>();
    private List<GameObject> blackAmongUsEnemies = new List<GameObject>();

    public GameObject plane;
    private Renderer planeRenderer;

    void Start() {
        planeRenderer = plane.GetComponent<Renderer>();
        for (int i = 0; i < maxEnemies; i++) {
            SpawnCubeEnemy();
            SpawnAmongUsEnemy();
        }
    }

    void Update() {
        // make sure there is always x amount of enemies
        if (cubeEnemies.Count < maxEnemies / 3) {
            SpawnCubeEnemy();
        }

        if (amongUsEnemies.Count < maxEnemies / 3) {
            SpawnAmongUsEnemy();
        }

        if (blackAmongUsEnemies.Count < maxEnemies / 3) {
            SpawnBlackAmongUsEnemy();
        }
    }

    void SpawnCubeEnemy() {
        // some random position on the surface of the plane , spawn an enemy , add to tracker
            //Debug.Log("Spawning cube enemy");
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newEnemy = Instantiate(CubeTemplate, randomPosition, transform.rotation);
        cubeEnemies.Add(newEnemy);
    }

    void SpawnAmongUsEnemy() {
            //Debug.Log("Spawning red among us enemy");
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newAmongUsEnemy = Instantiate(AmongUsTemplate, randomPosition, transform.rotation);
        amongUsEnemies.Add(newAmongUsEnemy);
    }

    void SpawnBlackAmongUsEnemy() {
            //Debug.Log("Spawning black among us enemy");
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newBlackAmongUsEnemy = Instantiate(blackAmongUsTemplate, randomPosition, transform.rotation);
        blackAmongUsEnemies.Add(newBlackAmongUsEnemy);
    }


    // destroy enemy and update list
    public void DestroyCubeEnemy(GameObject cubeEnemy){
        cubeEnemies.Remove(cubeEnemy);
        Destroy(cubeEnemy);
    }

    public void DestroyAmongUsEnemy(GameObject amongUsEnemy){
        amongUsEnemies.Remove(amongUsEnemy);
        Destroy(amongUsEnemy);
    }

    public void DestroyBlackAmongUsEnemy(GameObject blackAmongUsEnemy){
        blackAmongUsEnemies.Remove(blackAmongUsEnemy);
        Destroy(blackAmongUsEnemy);
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

