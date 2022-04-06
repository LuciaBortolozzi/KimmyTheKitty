using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, birdText, lifeText, gameOverScoreText, gameOverBirdText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject pauseButton;

    [SerializeField]
    private GameObject readyButton;
	
	void Awake ()
    {
        MakeInstance();
	}
	
	void MakeInstance ()
    {
        if(instance == null)
        {
            instance = this;
        }
	}

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void GameOverShowPanel(int finalScore, int finalBirdScore)
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        gameOverScoreText.text = finalScore.ToString();
        gameOverBirdText.text = finalBirdScore.ToString();
        StartCoroutine (GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneFader.instance.LoadLevel("Main Menu");
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetBirdScore(int birdScore)
    {
        birdText.text = "*" + birdScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "*" + lifeScore;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
