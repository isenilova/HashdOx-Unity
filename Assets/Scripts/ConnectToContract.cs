using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectToContract : MonoBehaviour
{
    public Text myDateTime;
    public Text myLocation;

    public string myPicUrl;

    public string status = "";


    public string myApiUrl;


    public GameObject myBackBut;
    public GameObject myGoodResult;
    public GameObject myBadResult;
    public GameObject myWait;


    public GameObject myPopup;

    public GameObject myHashTrObj;

    public GameObject mapCamera;


    public bool testMap = false;

    float ttm = 10f;

    ContractResult rs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenData() {

        GameParamsController.playerParams.DebugData();
        GameParamsController.myData.DebugClass();

       GameParamsController.myData.name = GameParamsController.playerParams.myName;
        GameParamsController.myData.time = myDateTime.text;
        GameParamsController.myData.location = myLocation.text;


        StartCoroutine(TakeUrl());

    }


    IEnumerator TakeUrl() {

        //here will be file saving




        //byte[] bytes;

        // bytes = tex.EncodeToPNG();


        //yield return new WaitForSeconds(1f);

        ttm = 10f;

        while ((GameParamsController.myData.hash == "fff")&&(ttm >0)) {

            ttm -= Time.deltaTime;
            yield return null;
        }

        if (ttm <= 0) {

            Debug.Log("FILE SAVE ERROR");
            //call win
            myBadResult.SetActive(true);
            myWait.SetActive(false);

            myPopup.GetComponent<PopUp>().GoUp();
            ttm = 10f;
            yield break;
        }
        //GameParamsController.myData.myUrl = myPicUrl;
        Debug.Log(GameParamsController.myData.hash);

        

        StartCoroutine(TestConnect());
        yield return null;

    }


   IEnumerator TestConnect() {


        var md = JsonUtility.ToJson(GameParamsController.myData);

        var w = new WWW(myApiUrl + "?data='" + md + "'");

        yield return w;


        Debug.Log((myApiUrl + "?data='" + md + "'").ToString());
        Debug.Log("SEGA " + w.text);
        Debug.Log("SEGA " + w.error);

        if (w.error == null)
        {
            //ok

            // myGoodResult.SetActive(true);

            mapCamera.GetComponent<MapSettings>().ShowGoodResult();

            rs = JsonUtility.FromJson<ContractResult>(w.text);
            Debug.Log(rs.result);

            if (rs.result != "true")
            {

                myHashTrObj.GetComponent<HashFill>().FillHash(rs.result);
            }

            else {

                myHashTrObj.GetComponent<Text>().text = "unknown";

            }


        }
        else
        {

            //THIS ONE FOR TEST
           if(testMap) mapCamera.GetComponent<MapSettings>().ShowGoodResult();
            myBadResult.SetActive(true);
           
        }

        myBackBut.SetActive(true);
        myWait.SetActive(false);

        //gameObject.SetActive(false);

        yield return null;
    }

}
