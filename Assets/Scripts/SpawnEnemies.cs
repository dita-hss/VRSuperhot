using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// currently debugging on why no new black or red among us enemies are spawning. 
// it shows that ht e count on the list is always 7 so it never meets the condition to spawn new ones
// but it is reaching the "destroy" function so im not sure what is going on 
// i think i need a "CubeHit" script seperate for the black and red among us enemies
public class SpawnEnemies : MonoBehaviour {
    public GameObject CubeTemplate;
    public GameObject AmongUsTemplate;
    public GameObject blackAmongUsTemplate;
    public GameObject greenAmongUsTemplate;

    public int maxEnemiesCubes = 3;
    public int maxEnemiesRed = 0;
    public int maxEnemiesBlack = 0;
    public int maxEnemiesGreen = 3;

    // keeping track of the enemies that are spawned and where they can be spawned
    private List<GameObject> cubeEnemies = new List<GameObject>();
    private List<GameObject> amongUsEnemies = new List<GameObject>();
    private List<GameObject> blackAmongUsEnemies = new List<GameObject>();
    private List<GameObject> greenAmongUsEnemies = new List<GameObject>();

    public GameObject plane;
    private Renderer planeRenderer;


    private int enemiesKilled;

    void Start() {
        enemiesKilled = 0;
        planeRenderer = plane.GetComponent<Renderer>();
        for (int i = 0; i < maxEnemiesCubes; i++) {
            SpawnCubeEnemy();
            SpawnAmongUsEnemy();
            SpawnBlackAmongUsEnemy();
        }
    }

    void Update() {
        if (enemiesKilled >= 5) {
            //if the current scence Scenes/Level2
            Debug.Log(SceneManager.GetActiveScene().name);
            if (SceneManager.GetActiveScene().name == "Level2") {
                SceneManager.LoadScene("Scenes/WinScene");
            }else {
                SceneManager.LoadScene("Scenes/Level2");
            }
            
        }
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

        if (greenAmongUsEnemies.Count < maxEnemiesGreen) {
            SpawnGreenAmongUsEnemy();
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
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newAmongUsEnemy = Instantiate(AmongUsTemplate, randomPosition, transform.rotation);
        amongUsEnemies.Add(newAmongUsEnemy);
        
    }

    void SpawnBlackAmongUsEnemy() {
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newBlackAmongUsEnemy = Instantiate(blackAmongUsTemplate, randomPosition, transform.rotation);
        blackAmongUsEnemies.Add(newBlackAmongUsEnemy);
        
    }

    void SpawnGreenAmongUsEnemy() {
        Vector3 randomPosition = GetRandomPositionOnPlane();
        GameObject newGreenAmongUsEnemy = Instantiate(greenAmongUsTemplate, randomPosition, transform.rotation);
        greenAmongUsEnemies.Add(newGreenAmongUsEnemy);
        
    }


    // destroy enemy and update list
    public void DestroyCubeEnemy(GameObject cubeEnemy){
        cubeEnemies.Remove(cubeEnemy);
        Destroy(cubeEnemy);
        enemiesKilled++;
    }

    public void DestroyAmongUsEnemy(GameObject amongUsEnemy){
        amongUsEnemies.Remove(amongUsEnemy);
        Destroy(amongUsEnemy);
        enemiesKilled++;
            //Debug.Log(amongUsEnemies.Count);
            
    }

    public void DestroyBlackAmongUsEnemy(GameObject blackAmongUsEnemy){
        blackAmongUsEnemies.Remove(blackAmongUsEnemy);
        Destroy(blackAmongUsEnemy);
        enemiesKilled++;
            //Debug.Log(blackAmongUsEnemies.Count);
    }

    public void DestroyGreenAmongUsEnemy(GameObject greenAmongUsEnemy){
        greenAmongUsEnemies.Remove(greenAmongUsEnemy);
        Destroy(greenAmongUsEnemy);
        enemiesKilled++;
            //Debug.Log(greenAmongUsEnemies.Count);
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

