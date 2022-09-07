using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; } 
    public float ver { get; private set; }
    public bool w { get; private set; }
    public bool s { get; private set; }

    public event Action OnFire = delegate { }; 


    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        
        w = Input.GetKeyDown(KeyCode.W);
        s = Input.GetKeyDown(KeyCode.S);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnFire();
        }
    }
}