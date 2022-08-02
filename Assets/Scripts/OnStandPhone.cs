using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStandPhone : MonoBehaviour
{
    public bool standMode = false;
    public float myWaitTime = 5f;
    float tm = 0;


    public GameObject startButt;
    public GameObject photoBut;
    public GameObject nextButt;

    public GameObject sendButt;


    public GameObject goodRes;
    public GameObject badRes;

    public GameObject doneButt;
    public GameObject backButt;

    public AudioClip myPhotoSound;


    public GameObject[] blockObj;
    public GameObject[] testInfo;

    // Start is called before the first frame update
    void Start()
    {

        if (!standMode) return;


        for (int i = 0; i < blockObj.Length; i++) blockObj[i].SetActive(true);
        for (int i = 0; i < testInfo.Length; i++) testInfo[i].SetActive(false);

        StartCoroutine(goStandAction());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator goStandAction() {

        yield return new WaitForSeconds(myWaitTime);

        startButt.GetComponent<Button>().onClick.Invoke();


        yield return new WaitForSeconds(myWaitTime- 1);


        //start flashlight
        Easy_flashlight.open_flashlight();

        yield return new WaitForSeconds(1);
        Easy_flashlight.close_flashlight();
        yield return new WaitForSeconds(0.2f);

        photoBut.GetComponent<Button>().onClick.Invoke();

        // here will be sound
        AudioSource.PlayClipAtPoint(myPhotoSound, Camera.main.transform.position, 1f);

        Easy_flashlight.open_flashlight();
        yield return new WaitForSeconds(0.2f);
        Easy_flashlight.close_flashlight();

        


        yield return new WaitForSeconds(myWaitTime);

       nextButt.GetComponent<Button>().onClick.Invoke();

        while (!sendButt.activeSelf) {

            yield return null;


        }

        yield return new WaitForSeconds(myWaitTime);

        sendButt.GetComponent<Button>().onClick.Invoke();

        while (!goodRes.activeSelf && !badRes.activeSelf) {

            yield return null;



        }

        yield return new WaitForSeconds(myWaitTime);

        if (goodRes.activeSelf) {

            doneButt.GetComponent<Button>().onClick.Invoke();


        }

        else backButt.GetComponent<Button>().onClick.Invoke();

        yield return new WaitForSeconds(myWaitTime);



        StartCoroutine(goStandAction());
    }

}
