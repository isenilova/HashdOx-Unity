using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessResultData : MonoBehaviour
{
    public Text myName;
    public Text myLocation;
    public Text myTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {

        myName.text = GameParamsController.myData.name;
        myLocation.text = GameParamsController.myData.location;
        myTime.text = GameParamsController.myData.time;
        
    }

}
