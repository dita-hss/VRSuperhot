using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHit : MonoBehaviour
{
    public GameObject CubeTemplate;

    // void Update()
    // {
    //     // this line adds the Shoot method to the trigger action
    //     GameObject cubeEnemy = Instantiate(CubeTemplate, transform.position + new Vector3(0.5f,0.5f,0f), transform.rotation);
        
    // }
    private void OnCollisionEnter(Collision other)
    {
            //Debug.Log("HITTTTTT");
        Destroy(other.gameObject);
    }
}
