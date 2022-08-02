using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Text[] myNm;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<InputField>().text = GameParamsController.playerParams.myName; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateName() {


        GameParamsController.playerParams.myName = gameObject.GetComponent<InputField>().text;
        GameParamsController.Save();

        for (int i = 0; i < myNm.Length; i++) {

            if (GameParamsController.playerParams.myName != "") myNm[i].text = GameParamsController.playerParams.myName;

            else myNm[i].text = "Logout";


        }

    }


    public void DoOff() {

        gameObject.GetComponent<InputField>().interactable = false;



    }

    public void DoOn() {


        gameObject.GetComponent<InputField>().interactable = true;


    }



}
