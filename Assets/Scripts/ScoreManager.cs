using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int score;
    public GameManager theGM;
    public int Combo;

    Text text;

    // Use this for initialization
    void Start () {
        theGM = FindObjectOfType<GameManager>();
        text = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = ""+score;
	}

    public void Count_Score()
    {
        if (score < 99999999)
        {
            for (Combo = 1; Combo <= theGM.LinkedCorn.Count; Combo++)
            {
                if (Combo >= 20)
                {
                    if (Combo % 10 == 0)
                    {
                        //콤보이미지
                    }
                    score += 200;
                }
                else if (Combo >= 15)
                {
                    score += 150;
                }
                else if (Combo >= 10)
                {
                    if (Combo == 10)
                    {
                        //10콤보이미지
                    }
                    score += 100;
                }
                else if (Combo >= 5)
                {
                    score += 50;
                }
                else
                {
                    score += 30;
                }
            }
        }
        else
            score = 99999999;
    }
}
