using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {
    Text text;

    private ScoreManager theScore;
	// Use this for initialization
	void Start () {
        theScore = FindObjectOfType<ScoreManager>();
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = ""+theScore.score;
	}
}
