using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitWeb : MonoBehaviour
{

    public string mySite = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToWeb() {

        Application.OpenURL(mySite);

    }

}
