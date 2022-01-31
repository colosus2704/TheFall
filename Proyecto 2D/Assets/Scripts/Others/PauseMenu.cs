using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause;

    public static event Action<bool> GetPause = delegate { };

    public static bool paused = false;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
            {
                paused = true;
                Pause.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                paused = false;
                Pause.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        GetPause(paused);
    }
}
