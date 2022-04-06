using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    private void Start()
    {
        CheckToPlayTheMusic();
    }

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        //SceneManager.LoadSceneAsync("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
    }

    void CheckToPlayTheMusic()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        } else {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }

    }

    public void HighScoreMenu()
    {
        SceneManager.LoadSceneAsync("High Score");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadSceneAsync("Options");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadSceneAsync("Credits");
    }

    public void MusicButton()
    {
        if(GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        } else if (GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }
}
