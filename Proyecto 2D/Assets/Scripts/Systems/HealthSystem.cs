using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public event Action Death = delegate { };
    public event Action<int> LifeUpdated = delegate { };

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;
    
    private void Start()
    {
        ResetHealth();     
        LifeUpdated(GetHealth());
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;
        LifeUpdated(GetHealth());

        if (health <= 0)
        {
            health = 0;
            Death();
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    /*public int GetMaxHealth()
    {
        return maxHealth;
    }*/

}