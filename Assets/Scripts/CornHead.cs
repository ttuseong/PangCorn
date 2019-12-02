using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornHead : MonoBehaviour {
    public GameObject Corn;
    public int count = 0;
    public string Link_Sound;
    public string Boom_Sound;
    private GameManager theGM;
    private CornRotation theRotation;
    private SoundManager theSound;
    private CornControl theControl;
    private BoxCollider2D boxcol; // 박스콜라이더 변수화
    public bool isLinked = false;
    public bool cheack_active = true;
    bool isBorn;

    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        theGM = FindObjectOfType<GameManager>();
        theRotation = GetComponentInParent<CornRotation>();
        theSound = FindObjectOfType<SoundManager>();
        isBorn = false;
        boxcol.enabled = false;
    }

    private void Update()
    {
        if (isBorn == false) { // 생성될 때 최초실행 1회 이외에 안함
            StartCoroutine(cornBorn()); // 콘 실행
        } // if end
    }

    IEnumerator cornBorn() { // 콘이 생성되었을 때 실행하는 코루틴        
        yield return new WaitForSeconds(1f); // 코루틴 시작 후 1초 뒤에
        boxcol.enabled = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Corn")
        {
            theSound.Play(Link_Sound);
        }

        else if(other.gameObject.tag == "Fire")
        {
            theGM.Allstop = true;
            if (Corn.gameObject.tag == "UnripeCorn")
            {
                StartCoroutine(UnripeCorn_change());
            }
            else
            {
                First_Burn();
            }
        }
        else if (other.gameObject.tag == "FireCorn")
        {
            if(Corn.gameObject.tag=="Corn" || Corn.gameObject.tag == "Fixed")
            {
                StartCoroutine(ChangeCorn());
            }
            else
            {
                StartCoroutine(UnripeCorn_change());
            }    
        }
    }

    public void First_Burn()
    {
//theGM.Allstop = true;
        if (isLinked)
        {
            GameObject Load_corn = Resources.Load("Prefebs/RipCorn") as GameObject;
            GameObject RipCorn_1 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            GameObject RipCorn_2 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            RipCorn_1.transform.position = new Vector3(Corn.gameObject.transform.position.x - 0.5f, Corn.gameObject.transform.position.y, Corn.gameObject.transform.position.z);
            RipCorn_2.transform.position = new Vector3(Corn.gameObject.transform.position.x + 0.5f, Corn.gameObject.transform.position.y, Corn.gameObject.transform.position.z);
            Destroy(Corn);
        }
        else
        {
            GameObject Load_corn = Resources.Load("Prefebs/RipCorn") as GameObject;
            GameObject RipCorn = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            RipCorn.transform.position = Corn.gameObject.transform.position;
            Destroy(Corn);
        }
        theSound.Play(Boom_Sound);
    }

    IEnumerator UnripeCorn_change()
    {
        GameObject Load_corn = Resources.Load("Prefebs/Corn2") as GameObject;
        GameObject UnripeCorn = MonoBehaviour.Instantiate(Load_corn) as GameObject;

        UnripeCorn.transform.GetChild(0).GetComponent<CornRotation>().Rotation_z = Corn.transform.GetChild(0).GetComponent<CornRotation>().Rotation_z;

        UnripeCorn.transform.position = Corn.gameObject.transform.position;
        UnripeCorn.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, theRotation.Rotation_z);
        Corn.transform.GetChild(0).transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        Corn.transform.position = new Vector3(100, 0, 0);
        if (!isLinked)
        {
            yield return new WaitForSeconds(0.2f);
            theGM.Allstop = false;
        }
        Destroy(Corn);
    }

    IEnumerator ChangeCorn()
    {
        yield return new WaitForSeconds(0.2f);
        theGM.Allstop = true;
        if(isLinked)
        {
            GameObject Load_corn = Resources.Load("Prefebs/RipCorn") as GameObject;
            GameObject RipCorn_1 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            GameObject RipCorn_2 = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            RipCorn_1.transform.position = new Vector3(Corn.gameObject.transform.position.x - 0.5f, Corn.gameObject.transform.position.y, Corn.gameObject.transform.position.z);
            RipCorn_2.transform.position = new Vector3(Corn.gameObject.transform.position.x + 0.5f, Corn.gameObject.transform.position.y, Corn.gameObject.transform.position.z);
            Destroy(Corn);
        }
        else
        {
            GameObject Load_corn = Resources.Load("Prefebs/RipCorn") as GameObject;
            GameObject RipCorn = MonoBehaviour.Instantiate(Load_corn) as GameObject;
            RipCorn.transform.position = Corn.gameObject.transform.position;
            Destroy(Corn);
        }
        theSound.Play(Boom_Sound);
    }

}