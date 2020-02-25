using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float currentSpeed = 0f;
    float magnitude = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed  = PlayerController.instace.accel;
        if(currentSpeed > 50.0f){
            magnitude = currentSpeed/2500f;
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }else{
            transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
        }
    }
}
