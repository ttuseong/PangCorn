using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornDrop : MonoBehaviour {

    // Use this for initialization

    public int count = 0;
    public int limit = 100;
    public int change = 0;
    public bool DropControl;

    public int number;
    public float position_x;

    private GameObject target;
    private GameManager theGM;
    private int Random_num;
    private CornHead theHead;
    private CornRotation theRotation;
    private GameOver theOver;

	void Start () {
        theGM = GetComponent<GameManager>();
        theOver = FindObjectOfType<GameOver>();
        DropControl = true;
	}
	
	// Update is called once per frame 
	void Update () {
        if(!theGM.Allstop&&!theOver.Over)
        {
            Creat_corn();
        }
	}

    private void Random_Object()
    {

        if (Random_num < 70)
        {
            GameObject Load_corn = Resources.Load("Prefebs/Corn2") as GameObject;
            GameObject Corn = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            Corn.transform.position = new Vector3(position_x, 0, 0);
            Corn.GetComponentInChildren<CornRotation>().Random_Rotation();

        }
        else if (Random_num < 80)
        {
            GameObject Load_corn = Resources.Load("Prefebs/UnripeCorn2") as GameObject;
            GameObject Corn = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            Corn.transform.position = new Vector3(position_x, 0, 0);
            Corn.GetComponentInChildren<CornRotation>().Random_Rotation();
        }
        else if (Random_num < 90)
        {
            GameObject Load_corn = Resources.Load("Prefebs/FixedCorn") as GameObject;
            GameObject Corn = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            Corn.transform.position = new Vector3(position_x, 0, 0);
        }
        else {
            GameObject Load_corn = Resources.Load("Prefebs/LinkedCorn2") as GameObject;
            GameObject Corn = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            Corn.transform.position = new Vector3(position_x, 0, 0);
            theHead = FindObjectOfType<CornHead>();
            theHead.isLinked = true;
        }     
    }

    private void Creat_corn()
    {
        count++;

        SetPosition();

        if (count == limit && DropControl)
        {
            Random_Object();
            count = 0;
            change++;

            if (change % 5 == 0)
            {
                if (limit > 20)
                {
                    limit = 100 - change;
                }
            }
        }
    }

    private void SetPosition()
    {
        Random_num = Random.Range(0, 100);

        if (Random_num >=90 && Random_num <100)
        {
            number = Random.Range(0, 3);
            switch (number)
            {
                case 0:
                    position_x = -1;
                    break;
                case 1:
                    position_x = 0;
                    break;
                case 2:
                    position_x = 1;
                    break;
            }
        }
        else
        {
            number = Random.Range(0, 4);
            switch (number)
            {
                case 0:
                    position_x = -1.5f;
                    break;
                case 1:
                    position_x = -0.5f;
                    break;
                case 2:
                    position_x = 0.5f;
                    break;
                case 3:
                    position_x = 1.5f;
                    break;
            }
        }
    }
}

