using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornControl : MonoBehaviour {
    private GameManager theGM;
    private CornRotation theRotation;
    private bool Rotation_Cheack = true;
    public GameObject theControl;

    // Use this for initialization
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        theRotation = GetComponentInChildren<CornRotation>();

        if (gameObject.transform.tag == "Fixed")
        {
            Rotation_Cheack = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            theGM.CastRay();

            if (theGM.target == this.gameObject && Rotation_Cheack)
            {  //타겟 오브젝트가 스크립트가 붙은 오브젝트라면
                
                theRotation.Re_Rotation();
            }
        }

    }
}
