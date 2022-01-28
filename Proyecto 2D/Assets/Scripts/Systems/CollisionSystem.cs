using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{
    //public event Action<int> LoseHealth = delegate { }; // - CREANDO EL EVENTO - 
     
    [SerializeField]
    private int damage;

    //lo que sea con lo que sea
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collider2D other)
    {
        // Le quitamos "al otro" impactado nuestra vida maxima como impactador 
        //other.gameObject.GetComponent<HealthSystem>().ReduceHealth(gameObject.GetComponent<HealthSystem>().GetMaxHealth());

        // Le quitamos "al otro" impactado nuestra daño 
        other.gameObject.GetComponent<HealthSystem>().ReduceHealth(damage);
    }
}