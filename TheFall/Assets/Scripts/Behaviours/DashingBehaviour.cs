using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//this script is used to controll the dash of the entity you put it on, it has a cooldown so you can't press it all the time, to work it gives an event to the movement script

public class DashingBehaviour : MonoBehaviour
{
    public AudioClip Sound;

    public static event Action Dash = delegate { };

    private int Cooldown = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Cooldown <= 0)
        {
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
