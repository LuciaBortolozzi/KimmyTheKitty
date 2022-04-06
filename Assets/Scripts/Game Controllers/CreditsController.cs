using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    public void Return()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
