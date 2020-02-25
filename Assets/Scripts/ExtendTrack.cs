using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtendTrack : MonoBehaviour
{
    
    Globals globals;
    public GameObject FinishFlag;
    

    // Start is called before the first frame update
    void Start()
    {
        FinishFlag.transform.position = new Vector3(0,0,96+ 168*Globals.GetGlobals().trackLength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        globals = Globals.GetGlobals();
        if ((other.name == "Vehicle") && globals.rollName <= globals.trackLength)
        {
            GameObject newPipe = Instantiate(transform.parent.gameObject);
            newPipe.transform.Translate(new Vector3(0,0,168));
            newPipe.name = "Tube_Line_"+globals.rollName;
            globals.direction.x = Random.Range(0, 2) == 1 ? 1 : -1;
            ++globals.rollName;
            globals.direction.y = Random.Range(0, 2) == 1 ? 1 : -1;
            // print("x is now: " + globals.direction.x + " y is now: " + globals.direction.y);
            // if(globals.rollName == globals.trackLength){
                // FinishFlag.transform.SetParent(newPipe.transform);
                // FinishFlag.transform.position = new Vector3(0,0,transform.position.z + 336);
            // FinishFlag.transform.Translate(new Vector3(0,0,10f));
        //  }
        }else if(globals.rollName > globals.trackLength){
            StopWatch.instance.run = false;
            SceneManager.LoadScene("GameOver");
            print(PlayerController.instace.transform.position);
        }
        
    }
}