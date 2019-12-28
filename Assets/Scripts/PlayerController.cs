using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public static PlayerController instace;
    private float speed = 100.0f;
    public float accel = 0.0f;
    
    private float turnSpeed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    private float hoverHeight = 1.0f;
    private float terrainHeight;
    private Vector3 pos;
    public GameObject tube;
    public GameObject ObjectToCreate;
    private List<GameObject> obstacles = new List<GameObject>();
    private int rollNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        instace = this;
        pos = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if(Mathf.Abs(forwardInput) > 0.05f && accel <= speed)
        {
            if(Mathf.Sign(forwardInput) == 1)
            {
                accel+=0.1f;
            }
            else if(Mathf.Sign(forwardInput) == -1 && accel >= 0.1f)
            {
                accel-=0.1f;
            }
            // accel=accel+(Mathf.Sign(forwardInput)/10);
        }    
        Vector3 movement = Vector3.forward * Time.deltaTime * accel;
        transform.Translate(movement);
        if(movement.magnitude > 0.3f && Random.Range(0,101) > 98-(accel/90)){
            AddObstacle();
        }
        // Debug.Log(movement.magnitude);

        // if(forwardInput > 0.0f)
        //     tube.transform.localScale += new Vector3(0,0,Mathf.Abs(tube.transform.position.z+accel));

        // transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //transform.Translate(Vector3.up * Time.deltaTime * -1.0f);
     
    }

    void AddObstacle()
    {
        GameObject obj = Instantiate(ObjectToCreate);//, new Vector3(0,-0.133f, 5), new Quaternion());
        Vector3 point = Random.insideUnitCircle.normalized*6.43f;
        // Vector3 point = Random.onUnitSphere*6.43f;
        // obj.transform.localScale = new Vector3(3,3,3);
        // point.z = 0;
        
        obj.transform.SetParent(ObjectToCreate.transform.parent, false);
        obj.transform.position = point;
        Vector3 offset = new Vector3(0,0,200);
        offset.z += transform.position.z;
        obj.transform.Translate(offset, transform);
        obj.name = "obstacle_" + rollNum;
        ++rollNum;
        obstacles.Add(obj);
        if(obstacles.Count > 100){
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
        }
    }
}
