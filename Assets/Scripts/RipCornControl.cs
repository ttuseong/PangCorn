using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipCornControl : MonoBehaviour {
    [SerializeField]
    public GameObject RipCorn;

    private GameManager theGM;


    void Awake()
    {
        theGM = FindObjectOfType<GameManager>();
    }

	// Use this for initialization
	void Start () {
        theGM.LinkedCorn.Add(RipCorn);
	}
}
