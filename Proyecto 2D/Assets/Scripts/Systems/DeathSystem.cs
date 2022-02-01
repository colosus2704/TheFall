using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSystem : MonoBehaviour
{
    public static event Action MultiplierUp = delegate { };

    public GameObject GameOver;

    public GameObject Particles;

    public AudioClip Sound;

    void OnEnable()
    {
        GetComponent<HealthSystem>().Death += Dead;
    }

    void OnDisable()
    {
        GetComponent<HealthSystem>().Death -= Dead;
    }

    private void Dead()
    {
        if(gameObject.CompareTag("Player"))
        {
            PlaySound();
            GameOver.SetActive(true);
            Particles.SetActive(true);
        }
        else if (gameObject.CompareTag("Bats"))
        {
            PlaySound();
            gameObject.SetActive(false);
            MultiplierUp();
        }
        gameObject.SetActive(false);
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }

}