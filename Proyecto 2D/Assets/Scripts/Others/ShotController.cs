using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotController : MonoBehaviour
{
    void OnEnable()
    {
        MultiplierSystem.Updater += UpdateShots;
    }

    void OnDisable()
    {
        MultiplierSystem.Updater -= UpdateShots;
    }

    void UpdateShots(float Score)
    {
        if (Score < 2)
        {
            ShootingSystemData sh = Resources.Load<ShootingSystemData>("ShootingSystemData");
            Destroy(gameObject.GetComponent<TripleShootSystem>());
            ShootingSystem s = gameObject.AddComponent<ShootingSystem>();

            Debug.Log(s + "Soy la s");
            s.shootingdata = sh;
            Transform t = gameObject.GetComponent<FSM.Controller>().GetShotPoint(0);
            s.shotPoint = t;

            gameObject.GetComponent<PlayerController>().SetLauncher(s);
        }
        else if (Score >= 2)
        {
                ShootingSystemData sh = Resources.Load<ShootingSystemData>("TripleShootingSystemData");
                Destroy(gameObject.GetComponent<ShootingSystem>());
                TripleShootSystem s = gameObject.AddComponent<TripleShootSystem>();

                s.shootingdata = sh;
                Transform t = gameObject.GetComponent<FSM.Controller>().GetShotPoint(0);
                s.shotPoint = t;

                gameObject.GetComponent<PlayerController>().SetLauncher(s);

        }
    }
}
