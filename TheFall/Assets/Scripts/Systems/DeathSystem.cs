using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSystem : MonoBehaviour
{
    public static event Action MultiplierUp = delegate { };
    public static event Action DBscore = delegate { };

    public GameObject GameOver;

    public GameObject Particles;


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
        if (gameObject.CompareTag("Player"))
        {
            GameOver.SetActive(true);
            Particles.SetActive(true);
            DBscore();
        }
        else if (gameObject.CompareTag("Bats"))
        {
            gameObject.SetActive(false);
            MultiplierUp();
        }
        gameObject.SetActive(false);
    }

}