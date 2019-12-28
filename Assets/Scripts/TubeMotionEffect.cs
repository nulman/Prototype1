using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMotionEffect : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, 10);
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.z = player.transform.position.z;
        transform.position = temp;
        // transform.Rotate(Vector3.forward, Time.deltaTime * turnSpeed * -Input.GetAxis("Horizontal"));
    }
}
