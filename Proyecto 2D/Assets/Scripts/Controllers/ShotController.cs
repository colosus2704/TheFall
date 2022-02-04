using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotController : MonoBehaviour
{
    void OnEnable()
    {
        MultiplierSystem.CheckMultiplier += UpdateShots;
    }

    void OnDisable()
    {
        MultiplierSystem.CheckMultiplier -= UpdateShots;
    }

    void UpdateShots(float Score)
    {
        if (Score >= 2)
        {
            ShootingSystemData sh = Resources.Load<ShootingSystemData>("TripleShootingSystemData");
            Destroy(gameObject.GetComponent<ShootingSystem>());
            TripleShootSystem s = gameObject.AddComponent<TripleShootSystem>();

            s.shootingdata = sh;
            Transform t = gameObject.GetComponent<FSM.Controller>().GetShotPoint(0);
            AudioClip a = gameObject.GetComponent<FSM.Controller>().GetAudioClip(0);
            s.shotPoint = t;
            s.Sound = a;

            gameObject.GetComponent<PlayerController>().SetLauncher(s);

        }
    }
}
