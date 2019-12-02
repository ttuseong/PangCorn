using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    private GameManager theGM;
    public bool Not_Touch; // 터치 바로바로 못하게 막기용

    // Use this for initialization
    void Start () {
        theGM = FindObjectOfType<GameManager>();
        Not_Touch = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)&&!theGM.Allstop)
        {
            theGM.CastRay();

            if (theGM.target == this.gameObject && Not_Touch)
            {  //타겟 오브젝트가 스크립트가 붙은 오브젝트라면
                Not_Touch = false;
                StartCoroutine(Corn_AllDrop());
            }
        }
	}

    IEnumerator Corn_AllDrop()
    {
        GameObject Load_corn = Resources.Load("Prefebs/Corn2") as GameObject;
        GameObject Corn1 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
        Corn1.transform.position = new Vector3(-1.5f, 0, 0);
        GameObject Corn2 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
        Corn2.transform.position = new Vector3(-0.5f, 0, 0);
        GameObject Corn3 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
        Corn3.transform.position = new Vector3(0.5f, 0, 0);
        GameObject Corn4 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
        Corn4.transform.position = new Vector3(1.5f, 0, 0);

        yield return new WaitForSeconds(1f);

        Not_Touch = true;
    }
}
