using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRotate : MonoBehaviour
{
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(GetComponent<Renderer>().bounds.center);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, Time.deltaTime * (turnSpeed+PlayerController.instace.accel/5) * -horizontalInput);
    }
}
