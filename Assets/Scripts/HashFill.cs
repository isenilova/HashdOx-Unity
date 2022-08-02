using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HashFill : MonoBehaviour
{
   public Text myTxt;

    public GameObject saveBut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillHash(string hs) {

        myTxt.text = hs;
        saveBut.SetActive(true);

    }

    public void ClearHash() {


        myTxt.text = "";
        saveBut.SetActive(false);


    }



    public void CopyHash() {

        UniClipboard.SetText(myTxt.text);


    }
}
