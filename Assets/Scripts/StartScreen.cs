using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public float barralffa = 0.5f;
    public float spd = 1f;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(onStartScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator onStartScreen() {

        yield return new WaitForSeconds(1f);

        while (gameObject.GetComponent<CanvasGroup>().alpha > barralffa) {


            gameObject.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * spd;



            yield return null;

        }

        
        gameObject.SetActive(false);


        yield return null;
    }

}
