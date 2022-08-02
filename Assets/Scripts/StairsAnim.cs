using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairsAnim : MonoBehaviour
{
    public GameObject[] myImg;
    public Color32[] myCol;
    public float spd = 0.5f;
    float tm = 0;
    int curPointer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Recolor();


        StartCoroutine(MyStairsAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MyStairsAnim() {

        while (true)
        {
            tm += Time.deltaTime;

            if (tm >= spd) {

                tm = 0;

                curPointer++;

                if (curPointer >= myImg.Length) curPointer = 0;

                Recolor();


            }


            yield return null;
        }
    }

    void Recolor() {

        int k = curPointer;

        for (int i = 0; i < myImg.Length; i++) {



            myImg[i].GetComponent<Image>().color = myCol[k];

            k++;

            if (k >= myCol.Length) k = 0;


        }




    }
}
