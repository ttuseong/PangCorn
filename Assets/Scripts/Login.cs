using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    static public Login instance;


    public InputField IDInputField;
    public InputField PassInputField;
    public GameObject Message;
    public Text _text;
    public string LogUrl;
    public string ch_text;
    public string UserID;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Login_game()
    {
        LogUrl = "localhost:81/test/Login.php";
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        UserID = IDInputField.text;
        WWWForm from = new WWWForm();
        from.AddField("Input_user", IDInputField.text);
        from.AddField("Input_pass", PassInputField.text);

        WWW webRequest = new WWW(LogUrl, from);
        yield return webRequest;
        ch_text = webRequest.text;

        if (webRequest.text == "1")
        {
            _text.text = "로그인 성공";
        }
        else
        {
            _text.text = "로그인 실패";
        }
        Message.SetActive(true);
    }
}
