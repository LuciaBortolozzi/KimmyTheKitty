using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);

        fadeAnim.Play("FadeIn");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));

        SceneManager.LoadSceneAsync(level);

        fadeAnim.Play("FadeOut");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));

        fadePanel.SetActive(false);
        
    }
}
