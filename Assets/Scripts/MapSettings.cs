using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSettings : MonoBehaviour
{

    public Vector3 camPosDef = new Vector3();
    public Vector3 camPosMap = new Vector3();

    public float camSzDef;
    public float camSzMap;

    public float camFarDef;
    public float camFarMap;

    

    public float camXRotToMap = 90;
    public float camZRotToMap = 180;


    public GameObject defCanvas;
    public GameObject mapCanvas;

    public GameObject backButDefCanvas;


    public GameObject myLocData;
    public GameObject myMapSearchObj;

    public int preferZoom = 7;

    // Start is called before the first frame update
    void Start()
    {
        //SaveParam();

       // GoMapCam();

    }




    public void ShowGoodResult() {

        defCanvas.SetActive(false);
        mapCanvas.SetActive(true);

        //mapObj.SetActive(true);

        GoMapCam();

        CheckLocation();
    }

    public void CheckLocation() {


        if ((Input.location.status == LocationServiceStatus.Running))
        {

            myMapSearchObj.GetComponent<OnlineMaps>().position = new Vector2(Input.location.lastData.longitude, Input.location.lastData.latitude);

            myMapSearchObj.GetComponent<OnlineMaps>().zoom = preferZoom;

          // myMapSearchObj.GetComponent<OnlineMapsMarkerManager>().Create(Input.location.lastData.latitude, Input.location.lastData.longitude);

            OnlineMapsMarker mk = myMapSearchObj.GetComponent<OnlineMapsMarkerManager>().Create(Input.location.lastData.longitude, Input.location.lastData.latitude);

            




           myMapSearchObj.GetComponent<OnlineMaps>().position = new Vector2(Input.location.lastData.longitude, Input.location.lastData.latitude-5);
        }

        else {


           // myMapSearchObj.GetComponent<OnlineMaps>().position = new Vector2(40, 40);
           // myMapSearchObj.GetComponent<OnlineMaps>().zoom = preferZoom;

            //myMapSearchObj.GetComponent<OnlineMapsMarkerManager>().Create(40,40);

            //myMapSearchObj.GetComponent<OnlineMaps>().position = new Vector2(40, 39);

        }







    }



    public void GoBackToMainCanvas() {

        mapCanvas.SetActive(false);
        defCanvas.SetActive(true);

        // Debug.Log("MAP   "+mapCanvas.activeSelf);

        backButDefCanvas.GetComponent<Button>().onClick.Invoke();

        GoDefCam();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoDefCam() {

        Camera.main.transform.position = camPosDef;

        Camera.main.transform.Rotate(0, 0, -camZRotToMap);
        Camera.main.transform.Rotate(-camXRotToMap, 0, 0);


        Camera.main.orthographicSize = camSzDef;
        Camera.main.GetComponent<Camera>().farClipPlane = camFarDef;




    }


    public void SaveParam() {


        camPosDef = Camera.main.transform.position;
       camSzDef = Camera.main.orthographicSize;
        camFarDef = Camera.main.GetComponent<Camera>().farClipPlane;



    }

    public void GoMapCam()
    {


        Camera.main.transform.position = camPosMap;

        Camera.main.transform.Rotate(camXRotToMap, 0, 0);
        Camera.main.transform.Rotate(0, 0, camZRotToMap);

        Camera.main.orthographicSize = camSzMap;
        Camera.main.GetComponent<Camera>().farClipPlane = camFarMap;


    }






}
