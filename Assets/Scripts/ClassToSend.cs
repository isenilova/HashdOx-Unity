using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClassToSend
{
    public string hash = "defstr";
    public string name = "defnm";
    public string time = "deftm";
    public string location = "defloc";


    public void DebugClass() {

        Debug.Log("My data. MyURL: " + hash + " MyName: " + name + " myTime: " + time + "myLocation: " + location);


    }

}
