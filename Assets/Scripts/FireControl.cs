using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour {

    public GameObject[] thefire;
    public string Sound_Name;
    private SoundManager theSound;
    private bool isBurning = true;
    public bool check_Fire = false;
    public int[] Copy_Rotation;
    public int Random_index;
    public int Start_index;
    public int Pass_index;

    private GameManager theGM;

	// Use this for initialization
	void Start () {
        theSound = FindObjectOfType<SoundManager>();
        theGM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isBurning)
        {
            StartCoroutine(FireBurn());
        }
	}

    public void Random_create()
    {
        Random_index = Random.Range(1, 5);
        Start_index = Random.Range(0, 4);
        Pass_index = Random.Range(0, 3);
    }

    IEnumerator FireBurn()
    {
        isBurning = false;
        yield return new WaitForSeconds(3f);
        

        Random_create();

        StartCoroutine(Burn_start());

        yield return new WaitUntil(() => check_Fire = true);

        isBurning = true;
        check_Fire = false;
    }

    IEnumerator Burn_start()
    {
        if (!theGM.Allstop)
        {
            Copy_Rotation[0] = Start_index;
            Copy_Rotation[1] = Start_index;
            for (int i = 0; i < Random_index; i++)
            {
                thefire[Copy_Rotation[0]++].GetComponent<Animator>().SetBool("Burn", true);

                if (Copy_Rotation[0] > 3)
                {
                    Copy_Rotation[0] = 0;
                }    
            }

            theSound.Play(Sound_Name);
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < Random_index; i++)
            {
                thefire[Copy_Rotation[1]++].GetComponent<Animator>().SetBool("Burn", false);

                if (Copy_Rotation[1] > 3)
                {
                    Copy_Rotation[1] = 0;
                }
            }

            if (Copy_Rotation[0] == Copy_Rotation[1])
            {
                check_Fire = true;
            }
        }
    }
}
