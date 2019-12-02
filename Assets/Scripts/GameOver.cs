using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    [SerializeField]
    private GameManager theGM;
    private GameObject Image_stop;
    public GameObject Image_End;
    public ScoreManager Score;
    public bool Over = false;

    private CornDrop theDrop;
    public string LogUrl;

    public Login theLog;

    // Use this for initialization
    void Start () {
        LogUrl = "localhost:81/test/CreateScore.php";
        theGM = FindObjectOfType<GameManager>();
        Image_stop = GameObject.Find("StopImage");
        theDrop = FindObjectOfType<CornDrop>();
        theLog = FindObjectOfType<Login>();
        Score = FindObjectOfType<ScoreManager>();
    }

    IEnumerator CreateSC()
    {
        WWWForm from = new WWWForm();
        from.AddField("Input_user", theLog.UserID);
        from.AddField("Input_score", Score.score);
        WWW webRequest = new WWW(LogUrl, from);
        yield return webRequest;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Head")
        {
            theGM.Allstop = true;
            Image_stop.GetComponent<Image>().enabled = true;
            theDrop.DropControl = false;
            Image_End.SetActive(true);
            Over = true;
            StartCoroutine(CreateSC());
        }
        
    }
}
