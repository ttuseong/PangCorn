using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour {

    public void SceneChange_()
    {
        SceneManager.LoadScene("Main");
    }
}
