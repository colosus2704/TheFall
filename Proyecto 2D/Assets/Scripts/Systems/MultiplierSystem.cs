using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultiplierSystem : MonoBehaviour
{
    public static event Action<float> Updater = delegate { };

    private float MultiplierScore = 1;
    private float Timer = 600;
    private bool paused = false;

    void OnEnable()
    {
        DeathSystem.MultiplierUp += Multiplier;
        PauseMenu.GetPause += Pause;
    }

    void OnDisable()
    {
        DeathSystem.MultiplierUp -= Multiplier;
        PauseMenu.GetPause -= Pause;
    }

    private void Multiplier()
    {
        Time.timeScale += 0.04f;
        MultiplierScore += 0.1f;
        Timer = 1000;

    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Timer--;
        }
        Updater(MultiplierScore);
        if (Timer <= 0 && paused == false)
        {
            MultiplierScore = 0;
            Time.timeScale = 1;
        }
    }
    private void Pause(bool pause)
    {
        paused = pause;
    }
}
