using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch_box : MonoBehaviour {
    public bool _Reg = false;
    public GameObject Join;
    public GameObject Reg;
    public GameObject box;

    public Create_Log theCr;
    public Login theLog;

    private void Start()
    {
        theCr = FindObjectOfType<Create_Log>();
        theLog = FindObjectOfType <Login>();
    }


    public void _Close()
    {
        if(_Reg && theCr.ch_text == "1")
        {
            box.SetActive(false);
            Reg.SetActive(false);
            _Reg = false;
        }
        else if(_Reg && theCr.ch_text =="2")
        {
            box.SetActive(false);
        }
        else if(theLog.ch_text=="1")
        {
            box.SetActive(false);
            Join.SetActive(false);
        }
        else
        {
            box.SetActive(false);
        }

    }
}
