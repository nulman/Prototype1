using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 0.1)
            Debug.Log("collided!");
            PlayerController.instace.accel /= 10.0f;
    }
}
