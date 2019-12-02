using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStop : MonoBehaviour {
    public bool theClick = false;
    private GameOver theOver;
    private GameManager theGM;
    public GameObject Image_object;
    public GameObject target;

	// Use this for initialization
	void Start () {
        theGM = FindObjectOfType<GameManager>();
        theOver = FindObjectOfType<GameOver>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            theGM.CastRay();
            theClick = !theClick;

            if (theGM.target == target && theClick&&!theOver.Over)
            {
                Time.timeScale = 0;
                theGM.Allstop = true;
                Image_object.GetComponent<Image>().enabled=true;

            }
            else if(theGM.target == this.gameObject&& !theOver.Over)
            {
                Time.timeScale = 1;
                theGM.Allstop = false;
                Image_object.GetComponent<Image>().enabled = false;
            }

        }
    }
}
