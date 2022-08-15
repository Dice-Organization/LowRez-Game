using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public static bool GameIsPaused;
    [SerializeField]
    private GameObject _pauseMenu;
    private void Update() 
    {
        if(!Input.GetKeyDown(KeyCode.Escape))
            return;

        if(SceneManager.GetSceneByName("TitleScreen").isLoaded)
            return;

        if(GameIsPaused)    
            Resume();
        else
            Pause();
    }

    private void Pause()
    {
        SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance.MenuClip);
        Time.timeScale = 0;
        _pauseMenu?.SetActive(true);
        GameIsPaused = true;
    }

    public void Resume()
    {
        SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance.MenuClip);
        Time.timeScale = 1;
        _pauseMenu?.SetActive(false);
        GameIsPaused = false;
    }

    public void LoadScene()
    {
        SoundEffects.Instance.Audio.PlayOneShot(SoundEffects.Instance.MenuClip);
        GameManager.Instance.LoadScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
