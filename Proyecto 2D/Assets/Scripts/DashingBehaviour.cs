using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashingBehaviour : MonoBehaviour
{

    public static event Action Dash = delegate { };

    private int Cooldown = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S) && Cooldown <= 0)
        {
            Debug.Log("Estoy En Dash");
            Cooldown = 10;
            Dash();
        }
        else
        {
            Cooldown--;
        }
    }
}
