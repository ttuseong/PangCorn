using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click_Rank : MonoBehaviour {
    public Ranking theRank;
    public GameObject click;

    public Text[] _text = new Text[10];

    public string LogUrl;

    public void _Ranking()
    {
        LogUrl = "localhost:81/test/Rank.php";
        StartCoroutine(_Rank());       
    }

    IEnumerator _Rank()
    {
        WWWForm from = new WWWForm();
        WWW webRequest = new WWW(LogUrl, from);
        yield return webRequest;
        string[] arr = webRequest.text.Split(',');
        for (int i = 0; i < 10; i++)
        {
            _text[i].text = arr[i];
        }
    }

    public void theClick()
    {
       _Ranking();
        click.SetActive(true);
    }
}
