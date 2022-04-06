using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, birdText;

    public void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    public void SetScore(int score, int birdScore)
    {
        scoreText.text = score.ToString();
        birdText.text = birdScore.ToString();
    }

    void SetScoreBasedOnDifficulty()
    {
        if(GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyBirdScore());
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyBirdScore());
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyBirdScore());
        }
    }
	public void Return()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
