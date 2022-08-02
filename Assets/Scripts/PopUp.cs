using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject startobj;
    public GameObject endobj;
    public float spd = 10f;

    public string status = "";


   //public bool onCamera = false;
    //public bool changeCamera = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }


    public void GoUp() {

        if (status == "up") return;

        StartCoroutine(CallPopUp());
    }

    IEnumerator CallPopUp() {

        status = "up";


        while (gameObject.transform.position.y < endobj.transform.position.y) {

            //if (gameObject.transform.position.y < (endobj.transform.position.y+ spd * Time.deltaTime))
                transform.position = new Vector3(transform.position.x, transform.position.y + spd * Time.deltaTime, transform.position.z);

            if(gameObject.transform.position.y > endobj.transform.position.y)
                transform.position = new Vector3(transform.position.x, endobj.transform.position.y, transform.position.z);

            yield return null;



        }

        transform.position = new Vector3(transform.position.x, endobj.transform.position.y, transform.position.z);

        status = "";

       // if (onCamera) gameObject.GetComponent<ActDisObj>().GoActDis();

        yield return null;
    }

    public void GoDown() {

        if (status == "down") return;

        StartCoroutine(DownPopUp());

    }


    IEnumerator DownPopUp() {

        status = "down";

        while (gameObject.transform.position.y > startobj.transform.position.y)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y - spd * Time.deltaTime, transform.position.z);

            yield return null;



        }

        transform.position = new Vector3(transform.position.x, startobj.transform.position.y, transform.position.z);

        status = "";


        yield return null;



    }

    public void GoHome() {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, startobj.transform.position.y, gameObject.transform.position.z);

        status = "";


    }

}
