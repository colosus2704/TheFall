using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public int sceneIndex = 0;

    public void Play()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Options()
    {

    }

    public void MainMenu()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
