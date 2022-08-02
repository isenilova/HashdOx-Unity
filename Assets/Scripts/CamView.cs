using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CamView : MonoBehaviour
{
    public RawImage raw_image_video;

    private WebCamTexture cam_texture;

    bool isdone = false;


    public Text debugInfo;

    public string svName = "my.png";
    public Texture2D tex;

    public string apiSaveImg = "";

    public string picAd = "";

    byte[] bytes;

    public GameObject sendBut;
    public GameObject loadIcon;


    public static CamView instance;

    public int sizeNFT = 500;


    public GameObject myHashObj;

    public GameObject goUpObj;

    void Awake()
    {
        instance = this;
    }


    void OnEnable()
    {
        isdone = false;

        if (Application.platform == RuntimePlatform.Android)
        {

            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {

                Debug.Log("No permition");
                Permission.RequestUserPermission(Permission.Camera);

            }

            /* while (!Input.location.isEnabledByUser) {


                 yield return null;
             }
             */

        }

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {

                Debug.Log("No permition");
                Application.RequestUserAuthorization(UserAuthorization.WebCam);

            }

           

        }


        StartCoroutine(this.start_webcam());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PressInc(string s)
    {
        if (s == "w+")
        {
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(this.raw_image_video.rectTransform.sizeDelta.x + 10, this.raw_image_video.rectTransform.sizeDelta.y);
        }
        if (s == "w-")
        {
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(this.raw_image_video.rectTransform.sizeDelta.x - 10, this.raw_image_video.rectTransform.sizeDelta.y);
        }
        if (s == "h+")
        {
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(this.raw_image_video.rectTransform.sizeDelta.x, this.raw_image_video.rectTransform.sizeDelta.y + 10);
        }
        if (s == "h-")
        {
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(this.raw_image_video.rectTransform.sizeDelta.x, this.raw_image_video.rectTransform.sizeDelta.y - 10);
        }



       // debugInfo.text = Screen.width + " " + cam_texture.width + " " + cam_texture.height + " " + this.raw_image_video.rectTransform.sizeDelta;

    }

    public void myTest(int k) {


        if (Application.platform != RuntimePlatform.IPhonePlayer) return;

        var devices = WebCamTexture.devices;
        var a = devices[0].availableResolutions[0];

        float ratio = ((float)a.height) / a.width;
        


        if (k == 0) this.raw_image_video.rectTransform.sizeDelta = new Vector2((1000 * 16) / 9, 1000);

        if (k == 4) this.raw_image_video.rectTransform.sizeDelta = new Vector2((1000 * Screen.height) / Screen.width, 1000);


        if (k == 3) this.raw_image_video.rectTransform.sizeDelta = new Vector2((int)(1000 * ratio), 1000);

        //if (k == 4) this.raw_image_video.rectTransform.sizeDelta = new Vector2((1000 * Screen.height) / Screen.width, 1000);

        // if (k ==1) this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.height / (float)this.cam_texture.width, Screen.width);


        //if(k==2) this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.width / (float)this.cam_texture.height, Screen.width);


        //if(k==3)  this.raw_image_video.rectTransform.sizeDelta = new Vector2((1000 * Screen.width) / Screen.height, 1000);


        //if (k == 3) this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.height * cam_texture.width / (float)this.cam_texture.width, Screen.width);


        //if (k == 3) this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.width*(1.777777f) / (float)this.cam_texture.height, Screen.width);


        //if (k == 4)  this.raw_image_video.rectTransform.sizeDelta = new Vector2((1000 * Screen.height) / Screen.width, 1000);



        Debug.Log("w="+(cam_texture.width).ToString()+ " h="+(cam_texture.height).ToString()+ 
            "("+(this.raw_image_video.rectTransform.sizeDelta.x/cam_texture.width).ToString()+"; "+ 
            (this.raw_image_video.rectTransform.sizeDelta.y/cam_texture.height).ToString()+")");
        


    }



    private IEnumerator start_webcam()
    {
        if (isdone) yield break;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

            // while (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            // yield return null;

            

                if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
                {

                    Debug.Log("No permition");
                Application.RequestUserAuthorization(UserAuthorization.WebCam);

                }





           // while (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            

                //Debug.Log("No permition");
                //Application.RequestUserAuthorization(UserAuthorization.WebCam);

           // yield return null;
            //}

        }



        yield return new WaitForSeconds(0.11f);




            //init camera texture
            this.cam_texture = new WebCamTexture();
        this.cam_texture.requestedFPS = 60;

        isdone = true;

        //this.cam_texture.requestedWidth = 720;
        //this.cam_texture.requestedHeight = 1280;

        this.cam_texture.requestedWidth = 1000;
        this.cam_texture.requestedHeight = 1000;

        //this.cam_texture.requestedWidth = 500;
        // this.cam_texture.requestedHeight = 500;


        this.cam_texture.Play();



        Debug.Log(Application.platform);

        if (Application.platform == RuntimePlatform.Android)
        {

          

            this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.width / (float)this.cam_texture.height, Screen.width);
            this.raw_image_video.rectTransform.rotation = Quaternion.Euler(0, 0, -90);
            this.raw_image_video.rectTransform.localScale = new Vector3(1, -1, 1);
            this.raw_image_video.rectTransform.localScale = new Vector3(1, 1, -1);

           // debugInfo.text = Screen.width + " " + cam_texture.width + " " + cam_texture.height + " " + this.raw_image_video.rectTransform.sizeDelta;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //this.raw_image_video.rectTransform.sizeDelta = new Vector2(1080, 1080 * this.cam_texture.width / (float)this.cam_texture.height);
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.height / (float)this.cam_texture.width, Screen.width);
            this.raw_image_video.rectTransform.localScale = new Vector3(-1, 1, 1);
            this.raw_image_video.rectTransform.rotation = Quaternion.Euler(0, 0, 90);

            //1000 == screen.width
            this.raw_image_video.rectTransform.sizeDelta = new Vector2((1000 * Screen.height) / Screen.width, 1000);
            //test

            float k;

            if (raw_image_video.rectTransform.sizeDelta.x > raw_image_video.rectTransform.sizeDelta.y)
                k = (Screen.width / raw_image_video.rectTransform.sizeDelta.y);
            else
                k = (Screen.width / raw_image_video.rectTransform.sizeDelta.x);


            this.raw_image_video.rectTransform.sizeDelta = new Vector2((int)(k* this.raw_image_video.rectTransform.sizeDelta.x),
                (int)(k * this.raw_image_video.rectTransform.sizeDelta.y));

            //debugInfo.text = Screen.width + " " + cam_texture.width + " " + cam_texture.height + " " + this.raw_image_video.rectTransform.sizeDelta;
        }
        else
        {
            //main code
            
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(1000 * (float)this.cam_texture.width / this.cam_texture.height, 1000);
            
            this.raw_image_video.rectTransform.localScale = new Vector3(-1, 1, 1);



            //test as IOS
            /*
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.height / (float)this.cam_texture.width, Screen.width);
            this.raw_image_video.rectTransform.localScale = new Vector3(-1, 1, 1);
            this.raw_image_video.rectTransform.rotation = Quaternion.Euler(0, 0, 90);
            
        */

            //test as android
            /*
            this.raw_image_video.rectTransform.sizeDelta = new Vector2(Screen.width * cam_texture.width / (float)this.cam_texture.height, Screen.width);
            this.raw_image_video.rectTransform.rotation = Quaternion.Euler(0, 0, -90);
            this.raw_image_video.rectTransform.localScale = new Vector3(1, -1, 1);
            this.raw_image_video.rectTransform.localScale = new Vector3(1, 1, -1);

            */


        }

        

        this.raw_image_video.texture = cam_texture;


      if(goUpObj.activeSelf)  goUpObj.GetComponent<PopUp>().GoUp();
        yield return null;
    }


    public void OnDisable()
    {
        

        if (this.cam_texture != null)
        {
            this.cam_texture.Stop();
        }

        isdone = false;
    }

    public void MakePhoto() {

        PreSave();
              

       raw_image_video.texture = tex;

        //mirror iphone
         if (Application.platform == RuntimePlatform.IPhonePlayer) {


             var tex1 = MirrorTexture(tex);

             raw_image_video.texture = tex1;


         }
 

        //test

        //var tex1 = MirrorTexture(tex);

        //raw_image_video.texture = tex1;

        //endtest


        if (this.cam_texture != null)
        {
            this.cam_texture.Stop();
        }

       

    }

    
    public void PreSave()
    {
        tex = new Texture2D(cam_texture.width, cam_texture.height);
        tex.SetPixels(cam_texture.GetPixels());
        tex.Apply();
    }




    public void CancelSave() {

        isdone = false;
        StartCoroutine(this.start_webcam());




    }


    public void ApproveSave()
    {
        cam_texture.Play();
        //StartCoroutine(start_webcam());

        string ppath = Application.persistentDataPath;
        Debug.Log(ppath);


        // change tex

       

        //tex resize + rotade

        

        bytes = tex.EncodeToPNG();

        if (Application.platform == RuntimePlatform.Android)
        {

            var tex1 = rotateTexture(tex, true);

            var tex2 = ResizeTexture(tex1);

            bytes = tex2.EncodeToPNG();

        }

        if (Application.platform == RuntimePlatform.IPhonePlayer) {


            var tex1 = CutTexture(tex);


            var tex2 = rotateTexture(tex1, true);

            var tex3 = ResizeTexture(tex2);


            bytes = tex3.EncodeToPNG();



        }

        //File.WriteAllBytes(ppath + "/resize" + svName, bytes/*tex.EncodeToPNG()*/);

        GameParamsController.myData.hash = "fff";

        StartCoroutine(ExtSaveImg());

    }

    IEnumerator ExtSaveImg() {

        //bytes + svName

        WWWForm form = new WWWForm();

        string myhash = "";

        myhash = Hash128.Compute(bytes).ToString();
        Debug.Log("HASH: " + myhash);

        //write hash

        myHashObj.GetComponent<HashFill>().FillHash(myhash);

        form.AddBinaryData("userImage", bytes, myhash+svName);


        using (UnityWebRequest www = UnityWebRequest.Post(apiSaveImg, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

                GameParamsController.myData.hash = "error";

            }
            else
            {
                // Print response
                Debug.Log(www.downloadHandler.text);

                //GameParamsController.myData.hash = picAd + GameParamsController.playerParams.myName + GameParamsController.playerParams.myRandId+svName;
                GameParamsController.myData.hash = myhash;

            }
        }




        sendBut.SetActive(true);
        loadIcon.SetActive(false);
       


        yield return null;
    }


    Texture2D rotateTexture(Texture2D originalTexture, bool clockwise)
    {
        Color32[] original = originalTexture.GetPixels32();
        Color32[] rotated = new Color32[original.Length];
        int w = originalTexture.width;
        int h = originalTexture.height;

        int iRotated, iOriginal;

        for (int j = 0; j < h; ++j)
        {
            for (int i = 0; i < w; ++i)
            {
                iRotated = (i + 1) * h - j - 1;
                iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                rotated[iRotated] = original[iOriginal];
            }
        }

        Texture2D rotatedTexture = new Texture2D(h, w);
        rotatedTexture.SetPixels32(rotated);
        rotatedTexture.Apply();
        return rotatedTexture;
    }

    public Texture2D ResizeTexture(Texture2D tex)
    {
       
        int w = sizeNFT;
        //w/h = 1280/720 -> h = w * 720 / 1280
        //0.5625
       // if (Application.platform == RuntimePlatform.Android)
        //{
            int h = w;
            float r = (float)tex.height / (float)sizeNFT;
            Texture2D tex1 = new Texture2D(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    tex1.SetPixel(i, j, tex.GetPixel((int)(i*r), (int)(j*r)));
                }
            tex1.Apply();
            return tex1;
       //}

        return tex;
        //put somewhere
    }



    public Texture2D CutTexture(Texture2D tex) {

        if (tex.width > tex.height) {

            float r = ((float)(tex.width - tex.height)) / 2f;

            Texture2D tex1 = new Texture2D(tex.height, tex.height);

            for (int i = 0; i < tex.height; i++)
                for (int j = 0; j < tex.height; j++) {

                    tex1.SetPixel(i, j, tex.GetPixel((int)(i + r), (int)j));


                }
            tex1.Apply();
            return tex1;


        }



        return tex;
    }


    public Texture2D MirrorTexture(Texture2D tex) {

        Texture2D tex1 = new Texture2D(tex.width, tex.height);

        for (int i = 0; i < tex.width; i++)
            for (int j = 0; j < tex.height; j++)
            {

                tex1.SetPixel(i, j, tex.GetPixel((int)(i), (int)(tex.height -j)));


            }

        tex1.Apply();

        return tex1;
    }


}
