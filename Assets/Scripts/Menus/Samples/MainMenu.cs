using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMusic("Main Menu");
    }

    public void Play()
    {
        LevelManager.Instance.LoadScene("LD", "CrossFade");
        MusicManager.Instance.PlayMusic("Game");
    }
 
    public void Quit()
    {
        Application.Quit();
    }
}