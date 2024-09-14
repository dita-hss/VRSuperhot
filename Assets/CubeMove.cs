using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        this.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-100.0f, 100.0f));
        
    }
}

