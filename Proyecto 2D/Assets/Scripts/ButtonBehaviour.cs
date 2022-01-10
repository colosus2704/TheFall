using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OptionsMenu;

    public int sceneIndex = 0;

    public void Play()
    {
        SceneManager.LoadScene(sceneIndex);
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

    public void Exit()
    {
        Application.Quit();
    }
}
