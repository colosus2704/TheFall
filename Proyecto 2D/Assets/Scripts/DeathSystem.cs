using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathSystem : MonoBehaviour
{
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
        gameObject.SetActive(false);
    }

}