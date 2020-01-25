using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionStay(Collision other) {
        // if(other.relativeVelocity.magnitude > 0.1)
        // {
            // Debug.Log("collided with: " + other.gameObject.name);
            if(gameObject.name.StartsWith("obstacle")){
                PlayerController.instace.accel -= (PlayerController.instace.accel/10);
            }else if(gameObject.name.StartsWith("Power")){
                if(PlayerController.instace.accel < PlayerController.instace.speed){
                    PlayerController.instace.accel += 10;
                }else{
                    PlayerController.instace.accel += 5f;
                }
            }
            
        // }
        // Debug.Log(gameObject.name +" collided with: " + other.gameObject.name);
    }
}
