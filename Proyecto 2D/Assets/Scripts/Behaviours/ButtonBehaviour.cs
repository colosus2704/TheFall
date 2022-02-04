using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    
    [SerializeField]
    private GameObject OptionsMenu;

    [SerializeField]
    private GameObject Pause;

    public int sceneIndex = 0;

    private bool Paused = true;

    public void SceneLoader()
    {
        GC.Collect();
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    public void Options()
    {
        OptionsMenu.SetActive(true);
        Menu.SetActive(false);
    }

    public void MainMenu()
    {
        OptionsMenu.SetActive(false);
        Menu.SetActive(true);
    }
    public void TryAgain()
    {
        GC.Collect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        Paused = false;
        Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LeaderBoard()
    {
        Menu.SetActive(false);
        OptionsMenu.SetActive(true);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
