using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParamsController : MonoBehaviour
{
    public static GameParams playerParams;

    public static bool canCange = true;

    public static ClassToSend myData = new ClassToSend();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void Load()
    {
        if (PlayerPrefs.HasKey("player"))
        {
            playerParams = JsonUtility.FromJson<GameParams>(PlayerPrefs.GetString("player"));
        }
        else
        {

            playerParams = new GameParams();
            playerParams.myRandId = Random.Range(0, 100000);
            Save();
        }
    }


    public static void Save()
    {
        string s = JsonUtility.ToJson(playerParams);
        Debug.Log(s);
        PlayerPrefs.SetString("player", s);
    }

    private void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 2;
        Load();
    }


    public void SetChange(bool st) {

        canCange = st;

    }

}
