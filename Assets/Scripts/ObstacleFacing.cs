using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFacing : MonoBehaviour
{
    public GameObject tube;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rend = tube.GetComponent<Renderer>().bounds.center;
        // Vector3 temp = transform.parent.position;
        // temp.z = transform.position.z;
        // transform.LookAt(temp);
        Vector3 relativePos = rend - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        Quaternion LookAtRotation = Quaternion.LookRotation( relativePos );
        Quaternion LookAtRotationOnly_Z = Quaternion.Euler(transform.rotation.eulerAngles.x, 
        LookAtRotation.eulerAngles.y, LookAtRotation.eulerAngles.z);
        transform.rotation = LookAtRotationOnly_Z;
        // transform.rotation = rotation;
        // Debug.Log(rend.bounds.center);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
