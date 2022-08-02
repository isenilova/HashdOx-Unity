using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDisObj : MonoBehaviour
{

    public GameObject[] actObj;

    public GameObject[] disObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoActDis()
    {
        for (int i = 0; i < actObj.Length; i++) actObj[i].SetActive(true);


        for (int i = 0; i < disObj.Length; i++) disObj[i].SetActive(false);

    }



}
