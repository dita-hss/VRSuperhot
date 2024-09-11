using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletTemplate;
    public float shootPower = 10000f;
    public InputActionReference trigger;

    public bool automaticFire = false;


    // Start is called before the first frame update
    void Start()
    {
        // this line adds the Shoot method to the trigger action
        trigger.action.performed += Shoot;
        
    }

    // Shoots a bullet
    void Shoot(InputAction.CallbackContext __){
        // this line creates a new bullet object and adds it into the world
        //spawn the bullet a bit in front of the player
        GameObject bullet = Instantiate(BulletTemplate, transform.position, transform.rotation);
        
        // this line adds a force to the bullet object
        // bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
        // bullet.GetComponent<Rigidbody>().AddForce(transform.up * shootPower);
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        var vc = rb.velocity;
        vc.z = 0;
        vc.y = 0;
        rb.velocity = bullet.transform.forward * 40;
        Destroy(bullet, 0.5f);

    }

}