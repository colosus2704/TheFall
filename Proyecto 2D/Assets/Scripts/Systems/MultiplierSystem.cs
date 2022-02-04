using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultiplierSystem : MonoBehaviour
{
    public static event Action<float> Updater = delegate { };
    public static event Action<float> CheckMultiplier = delegate { };

    private float MultiplierScore = 1;
    private float Timer = 600;
    private bool paused = false;

    public AudioClip Sound;

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
        PlaySound();
        CheckMultiplier(MultiplierScore);

    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Timer--;
        }
        
        if (Timer <= 0 && paused == false)
        {
            MultiplierScore = 1;
            Time.timeScale = 1;
        }
        Updater(MultiplierScore);

    }
    private void Pause(bool pause)
    {
        paused = pause;
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }
}
