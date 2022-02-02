using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShootSystem : ShootingSystem
{
    private int Shots = 3;

    public override void Shoot()
    {
        GameObject[] shot = new GameObject[Shots];

        if (shot != null)
        {
            for (int i = 0; i < Shots; i++)
            {
                shot[i].GetComponent<HealthSystem>().ResetHealth();
                shot[i].transform.position = shotPoint.position;

                //shot[i].transform.rotation = shotPoint.rotation;
                switch (i)
                {
                    case 0:
                        shot[i].transform.rotation = shotPoint.rotation;
                        break;
                }

                shot[i].SetActive(true);
                shot[i].GetComponent<Rigidbody2D>().AddForce(transform.right * shootingdata.fireForce);
            }
        }

    }
}
