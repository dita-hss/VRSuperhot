using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class TimeManage : MonoBehaviour
{
    public GameObject rightHandReference;

    public InputActionReference trigger;
    public Vector3 velocity;
    private Vector3 previousHandPosition;


    //test and trial showed the vr simulation to have speeds between 0 and ~100 
    //have to move super fast to reach numbers around 100 -- looks to have good movement with 60f
    public float maxSpeed = 40f;
    public float minSpeed = 0f;


    void Start()
    {
        // init the previous hand position to the current hand position
        previousHandPosition = rightHandReference.transform.position;
    }
    

    void Update() {
        // velotcity is the current hand position - the previous hand position divided by the time it took to get there
            //Debug.Log("delta" + Time.deltaTime);
        
            // **** maybe can use Time.unscaledDeltaTime to avoid division by 0
        velocity = (rightHandReference.transform.position - previousHandPosition) / Time.deltaTime;
        // speed is the magnitude of the velocity
        float speed = velocity.magnitude;
   

        // speed debug
            //Debug.Log("speed" + speed);

        // keep the speed between 0 and 1 for the timescale
        float normalizedSpeed = (speed - minSpeed) / (maxSpeed - minSpeed);
        // normalized speed debug
            //Debug.Log("normalizedSpeed" + normalizedSpeed);
        if (normalizedSpeed < 0) normalizedSpeed = 0.01f;
        if (normalizedSpeed > 1) normalizedSpeed = 1;

        Time.timeScale = normalizedSpeed;
        //timescael debug
            //Debug.Log("timescale" + Time.timeScale);
        
        // reset the previous hand position to the current hand position
        previousHandPosition = rightHandReference.transform.position;
       
    }
}
