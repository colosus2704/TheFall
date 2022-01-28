using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private MovementBehavior _movementBehavior;

    private void Awake()
    {
        _movementBehavior = GetComponent<MovementBehavior>();
    }

    void Update()
    {
        _movementBehavior.Move();
    }
}
