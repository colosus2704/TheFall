using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSystem : MonoBehaviour
{
    public static event Action MultiplierUp = delegate { };

    public GameObject GameOver;

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
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (gameObject.CompareTag("Bats"))
        {
            gameObject.SetActive(false);
            MultiplierUp();
        }
        gameObject.SetActive(false);
    }

}