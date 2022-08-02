using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectTransformController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMaskOn() {

        gameObject.GetComponent<RectMask2D>().enabled = true;


    }

    public void SetMaskOff() {


        gameObject.GetComponent<RectMask2D>().enabled = false;


    }
}
