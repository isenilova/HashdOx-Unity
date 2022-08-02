using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class DataUpdate : MonoBehaviour
{
    public Text myDateTime;
    public Text myLocation;
    public Text myName;
    public Text myName2;

    public float lastLat = 0;
    public float lastLong = 0;


    private void Awake()
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {

                Debug.Log("No permition");
                Permission.RequestUserPermission(Permission.FineLocation);

            }

            /* while (!Input.location.isEnabledByUser) {


                 yield return null;
             }
             */

        }


        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {

                Debug.Log("No permition");
                Permission.RequestUserPermission(Permission.Camera);

            }

            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {

                Debug.Log("No permition");
                Application.RequestUserAuthorization(UserAuthorization.WebCam);

            }


        }


    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameParamsController.playerParams.myName != "")
            myName.text = GameParamsController.playerParams.myName;
        else myName.text = "Logout";

        StartCoroutine(CheckLocation());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameParamsController.canCange) return;

        myDateTime.text = System.DateTime.Now.ToString();

        if (Input.location.status == LocationServiceStatus.Running)
        {
            myLocation.text = Input.location.lastData.latitude.ToString() + "N " + Input.location.lastData.longitude + "E";
            lastLat = Input.location.lastData.latitude;
            lastLong = Input.location.lastData.longitude;

        }
        else myLocation.text = "unknown";
        
    }

    IEnumerator CheckLocation() {

        Debug.Log("Location status: "+Input.location.isEnabledByUser);

        if (Application.platform == RuntimePlatform.Android) {

            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {

                Debug.Log("No permition");
                Permission.RequestUserPermission(Permission.FineLocation);
               
            }

           /* while (!Input.location.isEnabledByUser) {


                yield return null;
            }
            */

        }

        Debug.Log("Location status: " + Input.location.isEnabledByUser);


        if (!Input.location.isEnabledByUser) yield break;

        Debug.Log("Location enable");

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Debug.Log("Location timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
           Debug.Log("Location: unable to determine device location");
            yield break;
        }

        else
        {
           
            Debug.Log("Location: " + Input.location.lastData.latitude);
        }


        yield return null; 
    }

}
