using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject target;
    public bool Allstop;
    public List<GameObject> LinkedCorn;
    public string SoundName;

    private ScoreManager theScore;
    private int number = 0;
    private bool check = true;
    private SoundManager theSound;

    void Awake()
    {
        theSound = FindObjectOfType<SoundManager>();
        Allstop = false;
        theScore = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if(check)
        {
            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        check = false;
        number = LinkedCorn.Count;

        yield return new WaitForSeconds(0.3f);

        if (number == LinkedCorn.Count && number != 0)
        {
            theScore.Count_Score();
            for (int i = 0; i < LinkedCorn.Count; i++)
            {
                GameObject Boom_corn = Resources.Load("Prefebs/PopcornEffect") as GameObject;
                GameObject BCorn = MonoBehaviour.Instantiate(Boom_corn) as GameObject;
                BCorn.transform.position = LinkedCorn[i].transform.position;
                Destroy(LinkedCorn[i]);   
            }
            theSound.Play(SoundName);
            LinkedCorn.Clear();
            Allstop = false;
        } 
        check = true;
    }
     
    public void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        { //히트되었다면 여기서 실행
 

            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
