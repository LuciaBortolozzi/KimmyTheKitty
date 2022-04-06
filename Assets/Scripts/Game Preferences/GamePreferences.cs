using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {

    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyBirdScore = "EasyDifficultyBirdScore";
    public static string MediumDifficultyBirdScore = "MediumDifficultyBirdScore";
    public static string HardDifficultyBirdScore = "HardDifficultyBirdScore";

    public static string IsMusicOn = "IsMusicOn";

    // NOTE we are going to use integers to represent boolean variables
    // 0 = false, 1 = true

    // Music

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }

    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
    }

    //Difficulty

    public static void SetEasyDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
    }

    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    public static void SetMediumDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
    }

    public static int GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }

    public static void SetHardDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
    }

    public static int GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }

    //High Score

    public static void SetEasyDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, score);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, score);
    }

    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, score);
    }

    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }

    // Bird Score

    public static void SetEasyDifficultyBirdScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyBirdScore, score);
    }

    public static int GetEasyDifficultyBirdScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyBirdScore);
    }

    public static void SetMediumDifficultyBirdScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyBirdScore, score);
    }

    public static int GetMediumDifficultyBirdScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyBirdScore);
    }

    public static void SetHardDifficultyBirdScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyBirdScore, score);
    }

    public static int GetHardDifficultyBirdScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyBirdScore);
    }
}
