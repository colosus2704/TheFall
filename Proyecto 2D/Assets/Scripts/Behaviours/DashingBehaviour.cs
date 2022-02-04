using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashingBehaviour : MonoBehaviour
{
    public AudioClip Sound;

    public static event Action Dash = delegate { };

    private int Cooldown = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Cooldown <= 0)
        {
            Debug.Log("Estoy En Dash");
            Cooldown = 90;
            Dash();
            PlaySound();
        }
        else
        {
            Cooldown--;
        }
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }
}
