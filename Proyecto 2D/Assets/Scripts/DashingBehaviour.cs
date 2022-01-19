using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashingBehaviour : MonoBehaviour
{

    public event Action Dash = delegate { };

    private int Cooldown = 60;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S) && Cooldown <= 0)
        {
            Dash();
        }
        else
        {
            Cooldown--;
        }
    }
}
