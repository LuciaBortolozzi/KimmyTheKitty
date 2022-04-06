using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, birdScore, lifeScore;
    
    void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey ("Game Initialized"))
        {
            GamePreferences.SetEasyDifficultyState(0);
            GamePreferences.SetEasyDifficultyHighScore(0);
            GamePreferences.SetEasyDifficultyBirdScore(0);

            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyHighScore(0);
            GamePreferences.SetMediumDifficultyBirdScore(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyHighScore(0);
            GamePreferences.SetHardDifficultyBirdScore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 0);
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {       //GameManager.instance.
            if (gameRestartedAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetBirdScore(birdScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.birdCount = birdScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.birdCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetBirdScore(0);
                GameplayController.instance.SetLifeScore(2);
            }
        }
    }
    
    public void CheckGameStatus(int score, int birdScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            if(GamePreferences.GetEasyDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetEasyDifficultyHighScore();
                int birdHighScore = GamePreferences.GetEasyDifficultyBirdScore();

                if (highScore < score)
                    GamePreferences.SetEasyDifficultyHighScore(score);
                if (birdHighScore < birdScore)
                    GamePreferences.SetEasyDifficultyBirdScore(birdScore);
            }

            if (GamePreferences.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighScore();
                int birdHighScore = GamePreferences.GetMediumDifficultyBirdScore();

                if (highScore < score)
                    GamePreferences.SetMediumDifficultyHighScore(score);
                if (birdHighScore < birdScore)
                    GamePreferences.SetMediumDifficultyBirdScore(birdScore);
            }

            if (GamePreferences.GetHardDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighScore();
                int birdHighScore = GamePreferences.GetHardDifficultyBirdScore();

                if (highScore < score)
                    GamePreferences.SetHardDifficultyHighScore(score);
                if (birdHighScore < birdScore)
                    GamePreferences.SetHardDifficultyBirdScore(birdScore);
            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            
            GameplayController.instance.GameOverShowPanel(score, birdScore);
        }
        else
        {
            this.score = score;
            this.birdScore = birdScore;
            this.lifeScore = lifeScore;
            
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GameplayController.instance.PlayerDiedRestartTheGame();
        }
    }
}