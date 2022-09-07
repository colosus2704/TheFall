using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private MovementBehavior _movementBehavior;
    
    private float speedUpOverTime = 0.00001f;

    private void Awake()
    {
        _movementBehavior = GetComponent<MovementBehavior>();
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            _movementBehavior.Move();
            Time.timeScale = Time.timeScale + speedUpOverTime;
        }
    }
}

//This script is used to move the obstacles towards the player and give them more speed the more you survive to make it get harder over time.