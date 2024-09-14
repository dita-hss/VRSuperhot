using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemies : MonoBehaviour
{
    public GameObject CubeTemplate;
    // Start is called before the first frame update
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public GameObject Enemy8;
    public GameObject Enemy9;


    void Start(){
        Enemy1  = Instantiate(CubeTemplate, transform.position + new Vector3(0.5f,0.1f,0f), transform.rotation);
        Enemy2  = Instantiate(CubeTemplate, transform.position + new Vector3(2f,0.2f,0f), transform.rotation);
        Enemy3  = Instantiate(CubeTemplate, transform.position + new Vector3(1.5f,0.3f,0f), transform.rotation);
        Enemy4  = Instantiate(CubeTemplate, transform.position + new Vector3(-0.5f,0.1f,0f), transform.rotation);
        Enemy5  = Instantiate(CubeTemplate, transform.position + new Vector3(-2f,0.2f,0f), transform.rotation);
        Enemy6  = Instantiate(CubeTemplate, transform.position + new Vector3(-1.5f,0.3f,0f), transform.rotation);

        Enemy7  = Instantiate(CubeTemplate, transform.position + new Vector3(-0.5f,-2.1f,-5.0f), transform.rotation);
        Enemy8  = Instantiate(CubeTemplate, transform.position + new Vector3(-2f, 0.2f,-3.0f), transform.rotation);
        Enemy9  = Instantiate(CubeTemplate, transform.position + new Vector3(-1.5f,0.3f,-7.0f), transform.rotation);
    }

}
