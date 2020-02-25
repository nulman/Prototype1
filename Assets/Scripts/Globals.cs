using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public static Globals instance;
    public int rollName = 0;
    public string formattedRunTime = "you shouldn't see this";
    public int trackLength = 25;
    public Vector2 direction = new Vector2(0,0);

    public static Globals GetGlobals(){
        if(instance == null)
        {
            instance = new Globals();
        }
        return instance;
    }

    public void Reset() {
        rollName = 0;
        direction.x = 0;
        direction.y = 0;
    }
}
