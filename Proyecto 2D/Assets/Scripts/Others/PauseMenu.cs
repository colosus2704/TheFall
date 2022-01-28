using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause;

    private bool Paused = false;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused == false)
            {
                Paused = true;
                Pause.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Paused = false;
                Pause.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
