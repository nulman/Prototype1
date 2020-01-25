using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StopWatch : MonoBehaviour
{
    Text text;
    float runTime;
    public string formattedRunTime;
    public static StopWatch instance;
    public bool run = true;
    //Globals globals;
    // Start is called before the first frame update
    void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        instance = this;
        //globals = Globals.GetGlobals();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(run == true)
        {
            runTime += Time.deltaTime;
            formattedRunTime = Mathf.Floor((runTime % 3600) / 60).ToString("00") + 
                ":" + (runTime % 60).ToString("00") + ":" +  
                (runTime*1000 % 1000).ToString("000");
            GetComponent<TextMeshProUGUI>().text = "Time: " + formattedRunTime;
            Globals.GetGlobals().formattedRunTime = formattedRunTime;
        }
    }
}
