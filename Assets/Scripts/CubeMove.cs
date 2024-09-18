using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private Rigidbody rb;
    public float minSpeed = -30.0f;
    public float maxSpeed = 30.0f;



    private Renderer planeRenderer;
    public GameObject plane;
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    void Start() {
        rb = GetComponent<Rigidbody>();
        planeRenderer = plane.GetComponent<Renderer>();

        Bounds planeBounds = planeRenderer.bounds;
        minX = planeBounds.min.x;
        maxX = planeBounds.max.x;
        minZ = planeBounds.min.z;
        maxZ = planeBounds.max.z;
    }

    void Update()
    {
        //force only in the XZ plane
            //problem- since it is a force, it is still possible for the force to push it outside of the bounds
        Vector3 forceMove = new Vector3( Random.Range(minSpeed, maxSpeed), 0.0f, Random.Range(minSpeed, maxSpeed));
        rb.AddForce(forceMove);

            // temporary solution- make sure to clamp the positions to the boundary
                // problem- it seems that it is possible for a block to get stuck in this position indefinetely
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),transform.position.y,Mathf.Clamp(transform.position.z, minZ, maxZ));
        transform.position = clampedPosition;
    }
}
