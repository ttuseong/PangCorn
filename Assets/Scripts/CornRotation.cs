using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornRotation : MonoBehaviour {

    public float number;
    public float Rotation_z;
    public string Sound_Name;

    private GameManager theGM;
    private SoundManager theSound;

    void Start()
    {
        theSound = FindObjectOfType<SoundManager>();
        theGM = FindObjectOfType<GameManager>();
    }

    public void Random_Rotation()
    {
        number = Random.Range(0, 4);
        Rotation_z = number * 90;
        transform.rotation = Quaternion.Euler(0, 0, Rotation_z);
     }
	
	// Update is called once per frame
    public void Re_Rotation()
    {
        if(!theGM.Allstop)
        {
            Rotation_z -= 90;
            if (Rotation_z < -270)
                Rotation_z = 0;
            transform.rotation = Quaternion.Euler(0, 0, Rotation_z);
            theSound.Play(Sound_Name);
        }
    }
}
