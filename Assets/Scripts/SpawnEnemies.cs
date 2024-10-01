using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// currently debugging on why no new black or red among us enemies are spawning. 
// it shows that ht e count on the list is always 7 so it never meets the condition to spawn new ones
// but it is reaching the "destroy" function so im not sure what is going on 
// i think i need a "CubeHit" script seperate for the black and red among us enemies
public class SpawnEnemies : MonoBehaviour {
    public GameObject CubeTemplate;
    public GameObject AmongUsTemplate;
    public GameObject blackAmongUsTemplate;

    public int maxEnemiesCubes = 7;
    public int maxEnemiesRed = 7;
    public int maxEnemiesBlack = 7;

    // keeping track of the enemies that are spawned and where they can be spawned
    private List<GameObject> cubeEnemies = new List<GameObject>();
    private List<GameObject> amongUsEnemies = new List<GameObject>();
    private List<GameObject> blackAmongUsEnemies = new List<GameObject>();

    public GameObject plane;
    private Renderer planeRenderer;

    void Start() {
        planeRenderer = plane.GetComponent<Renderer>();
        for (int i = 0; i < maxEnemiesCubes; i++) {
            SpawnCubeEnemy();
            SpawnAmongUsEnemy();
            SpawnBlackAmongUsEnemy();
        }
    }

    void Update() {
        // make sure there is always x amount of enemies
        if (cubeEnemies.Count < maxEnemiesCubes) {
            SpawnCubeEnemy();
        }

        if (amongUsEnemies.Count < maxEnemiesRed) {
            SpawnAmongUsEnemy();
        }

        if (blackAmongUsEnemies.Count < maxEnemiesBlack) {
            SpawnBlackAmongUsEnemy();
        }
    }

    void SpawnCubeEnemy() {
        // some random position on the surface of the plane , spawn an enemy , add to tracker
            //Debug.Log("Spawning cube enemy");
            // Debug.Log(amongUsEnemies.Count);
            // Debug.Log(blackAmongUsEnemies.Count);
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newEnemy = Instantiate(CubeTemplate, randomPosition, transform.rotation);
        cubeEnemies.Add(newEnemy);
    }

    void SpawnAmongUsEnemy() {
            Debug.Log("Spawning red among us enemy");
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newAmongUsEnemy = Instantiate(AmongUsTemplate, randomPosition, transform.rotation);
        amongUsEnemies.Add(newAmongUsEnemy);
    }

    void SpawnBlackAmongUsEnemy() {
            Debug.Log("Spawning black among us enemy");
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
            Debug.Log(amongUsEnemies.Count);
            
    }

    public void DestroyBlackAmongUsEnemy(GameObject blackAmongUsEnemy){
        blackAmongUsEnemies.Remove(blackAmongUsEnemy);
        Destroy(blackAmongUsEnemy);
            Debug.Log(blackAmongUsEnemies.Count);
    }

    Vector3 GetRandomPositionOnPlane() {
        // bounds of the plane on xz plane
        Bounds planeBounds = planeRenderer.bounds;

        // random x and Z positions within the bounds of the plane
        float randomX = Random.Range(planeBounds.min.x, planeBounds.max.x);
        float randomZ = Random.Range(planeBounds.min.z, planeBounds.max.z);

        // so its not inside
        float yPosition = planeBounds.max.y + 0.1f;

        return new Vector3(randomX, yPosition, randomZ);
    }
}

