using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameParams
{

    public string myName = "";

    public int myRandId = 0;



    public void DebugData() {

        Debug.Log("My name: " + myName+ "My rand num: " + myRandId);

    }

}
