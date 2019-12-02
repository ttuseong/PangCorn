using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Log : MonoBehaviour {

    public InputField New_IDInputField;
    public InputField New_PassInputField;

    public string LogUrl;
    public GameObject CreateAccountPanel;
    public GameObject Message;
    public Text _text;
    public ch_box theBox;
    public string ch_text;

    private void Start()
    {
        theBox = FindObjectOfType<ch_box>();
    }

    public void ch_Btn()    
    {
        CreateAccountPanel.SetActive(true);
        theBox._Reg = true;
    }

    public void _Create_Log()
    {
        LogUrl = "localhost:81/test/CreateID.php";
        StartCoroutine(CreateIDCo());
    }

    IEnumerator CreateIDCo()
    {
        WWWForm from = new WWWForm();
        from.AddField("Input_user", New_IDInputField.text);
        from.AddField("Input_pass", New_PassInputField.text);
        WWW webRequest = new WWW(LogUrl, from);
        yield return webRequest;
        ch_text = webRequest.text;

        if (webRequest.text == "1")
            _text.text = "회원가입 성공";
        else
            _text.text = "회원가입 실패";

        Message.SetActive(true);
    }

}
